using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.IO;
using System.Drawing.Imaging;


namespace PRY_SERVICESNOW
{
    internal class cls_reportes
    {

        // ==================================================
        // CONSULTA 1
        // RESERVAS CON SALA, TRABAJADOR Y TIPO DE SALA
        // ==================================================
        public DataTable ObtenerReservas()
        {
            DataTable tabla = new DataTable();
            cls_Conexion conexionBD = new cls_Conexion();

            try
            {
                using (MySqlConnection conexion =
                       conexionBD.AbrirConexion())
                {
                    string sql = @"
                        SELECT
                            R.id_reserva AS ID,
                            S.nombre AS Sala,
                            TS.nombre AS `Tipo de sala`,

                            CONCAT_WS(
                                ' ',
                                T.nombre,
                                T.apellidoP,
                                T.apellidoM
                            ) AS Trabajador,

                            P.puesto AS Puesto,
                            R.fecha_uso AS Fecha,

                            TIME_FORMAT(
                                R.hora_inicio,
                                '%H:%i'
                            ) AS `Hora de inicio`,

                            TIME_FORMAT(
                                R.hora_fin,
                                '%H:%i'
                            ) AS `Hora final`,

                            R.motivo AS Motivo,

                            CASE
                                WHEN R.estado = 1 THEN 'Activa'
                                ELSE 'Cancelada'
                            END AS Estado

                        FROM tbl_reservas AS R

                        INNER JOIN tbl_salas AS S
                            ON R.id_sala = S.id_sala

                        INNER JOIN tbl_tiposalas AS TS
                            ON S.id_tiposala = TS.id_tiposala

                        INNER JOIN tbl_trabajadores AS T
                            ON R.clave_trabajador =
                               T.clave_trabajador

                        INNER JOIN tbl_puesto AS P
                            ON T.id_puesto = P.id_puesto

                        ORDER BY
                            R.fecha_uso DESC,
                            R.hora_inicio ASC;";

                    using (MySqlDataAdapter adaptador =
                           new MySqlDataAdapter(sql, conexion))
                    {
                        adaptador.Fill(tabla);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(
                    "Error al obtener las reservas: " +
                    ex.Message
                );
            }

            return tabla;
        }

        // ==================================================
        // CONSULTA 2
        // SERVICIOS ASIGNADOS A TODAS LAS SALAS
        // ==================================================
        public DataTable ObtenerServiciosPorSala()
        {
            DataTable tabla = new DataTable();
            cls_Conexion conexionBD = new cls_Conexion();

            try
            {
                using (MySqlConnection conexion =
                       conexionBD.AbrirConexion())
                {
                    string sql = @"
                        SELECT
                            A.id_asignacionS AS ID,
                            S.nombre AS Sala,
                            TS.nombre AS `Tipo de sala`,
                            SV.servicio AS Servicio,

                            CASE
                                WHEN A.estado = 1 THEN 'Activo'
                                ELSE 'Inactivo'
                            END AS Estado

                        FROM tbl_asignacion_servicios AS A

                        INNER JOIN tbl_salas AS S
                            ON A.id_sala = S.id_sala

                        INNER JOIN tbl_tiposalas AS TS
                            ON S.id_tiposala = TS.id_tiposala

                        INNER JOIN tbl_servicios AS SV
                            ON A.id_servicios =
                               SV.id_servicio

                        ORDER BY
                            S.nombre,
                            SV.servicio;";

                    using (MySqlDataAdapter adaptador =
                           new MySqlDataAdapter(sql, conexion))
                    {
                        adaptador.Fill(tabla);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(
                    "Error al obtener los servicios por sala: " +
                    ex.Message
                );
            }

            return tabla;
        }

        // ==================================================
        // CONSULTA 3
        // MOBILIARIO ASIGNADO A TODAS LAS SALAS
        // ==================================================
        public DataTable ObtenerMobiliarioPorSala()
        {
            DataTable tabla = new DataTable();
            cls_Conexion conexionBD = new cls_Conexion();

            try
            {
                using (MySqlConnection conexion =
                       conexionBD.AbrirConexion())
                {
                    string sql = @"
                        SELECT
                            A.id_asignacionM AS ID,
                            S.nombre AS Sala,
                            M.nombre AS Mobiliario,
                            M.descripcion AS Descripción,
                            A.cantidad_pasada AS Cantidad,
                            A.folio AS Folio

                        FROM tbl_asignacion_mobiliario AS A

                        INNER JOIN tbl_salas AS S
                            ON A.id_sala = S.id_sala

                        INNER JOIN tbl_mobiliario AS M
                            ON A.id_mobiliario =
                               M.id_mobiliario

                        ORDER BY
                            S.nombre,
                            M.nombre;";

                    using (MySqlDataAdapter adaptador =
                           new MySqlDataAdapter(sql, conexion))
                    {
                        adaptador.Fill(tabla);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(
                    "Error al obtener el mobiliario por sala: " +
                    ex.Message
                );
            }

            return tabla;
        }

        public void ExportarPDF(DataTable tabla, string tituloReporte, string nombreArchivoSugerido)
        {
            if(tabla== null || tabla.Rows.Count == 0)
            {
                MessageBox.Show("no hay datos para convertir a PDF","Atencion", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            //Abre la ventana para abrir el archivo
            SaveFileDialog guardarArchivo = new SaveFileDialog();
            guardarArchivo.FileName = nombreArchivoSugerido;
            guardarArchivo.Filter = "Archivos PDF(*.pdf)|*pdf";

            if (guardarArchivo.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Document.Create(container =>
                    {
                        container.Page(page =>
                        {
                            page.Size(PageSizes.Letter.Landscape());
                            page.Margin(1.5f, Unit.Centimetre);
                            page.PageColor("#D9C7B8");
                            page.DefaultTextStyle(x => x.FontFamily(Fonts.Arial));

                            //Esto es para poner un titulo al reporte
                            page.Header().Row(row =>
                            {
                                row.RelativeItem().AlignLeft().AlignMiddle().Column(col =>
                                {
                                    col.Item().Text("Services && Now")
                                        .FontSize(10)
                                        .Bold()
                                        .FontColor("#5C4033");

                                    col.Item().PaddingTop(5).LineHorizontal(1).LineColor(Colors.Grey.Lighten2);

                                });

                                if (Properties.Resources.img_inicio != null)
                                {
                                    byte[] bytesLogo;

                                    using (MemoryStream memoria = new MemoryStream())
                                    {
                                        Properties.Resources.img_inicio.Save(
                                            memoria,
                                            System.Drawing.Imaging.ImageFormat.Png
                                        );

                                        bytesLogo = memoria.ToArray();
                                    }

                                    row.ConstantItem(90)
                                        .AlignRight()
                                        .AlignMiddle()
                                        .Image(bytesLogo);
                                }

                            });

                            //Parte 2 contenido central
                            page.Content().PaddingTop(20).Column(column =>
                                {
                                    //Aqui se imprime el titulo que le pases por parametro
                                    column.Item().Padding(15).Text(tituloReporte)// <--dinamico
                                        .FontSize(12).Bold().FontColor("#5C4033");

                                    //La tabla se construye sola segun las columnas que traiga el datatable
                                    column.Item().Table(table =>
                                    {
                                        int totalColumnas = tabla.Columns.Count;

                                        table.ColumnsDefinition(columns =>
                                        {
                                            for (int i = 0; i < totalColumnas; i++)
                                            {
                                                if (i > 0 && i < totalColumnas - 1)
                                                    columns.RelativeColumn(2f);
                                                else
                                                    columns.RelativeColumn(1.2f);
                                            }
                                        });

                                        //Nombres de las columnas en automatico de acuerdo a la tabla
                                        foreach (DataColumn columnaObj in tabla.Columns)
                                        {
                                            table.Cell().Background("#5C4033").Padding(8).AlignLeft().AlignMiddle()
                                                .Text(columnaObj.ColumnName).FontSize(10).Bold().FontColor("#FFFFFF");
                                        }
                                        //Filas automaticas
                                        bool alternarFila = true;
                                        foreach (DataRow fila in tabla.Rows)
                                        {
                                            string colorFondo = alternarFila ? "#FFFFFF" : "#F5F5F3";

                                            for (int i = 0; i < totalColumnas; i++)
                                            {
                                                var celda = table.Cell().Background(colorFondo)
                                                                 .BorderBottom(1).BorderColor("#B4B1AD")
                                                                 .Padding(7).AlignMiddle();

                                                if (i == 0 || i == (totalColumnas - 1))
                                                    celda.AlignCenter();
                                                else
                                                    celda.AlignLeft();

                                                celda.Text(fila[i].ToString()).FontSize(9).FontColor("#2F2926");

                                            }
                                            alternarFila = !alternarFila;
                                        }
                                    });

                                });
                            //Este es el pie de pagina 
                            page.Footer().AlignRight().Text(x =>
                                {
                                    x.Span("Pagina ").FontSize(9).FontColor("#5C4033");
                                    x.CurrentPageNumber().FontSize(9).Bold().FontColor("#5C4033");
                                    x.Span(" de ").FontSize(9).FontColor("#5C4033");
                                    x.TotalPages().FontSize(9).Bold().FontColor("#5C4033");
                                });
                        });
                    }).GeneratePdf(guardarArchivo.FileName);

                    MessageBox.Show("Reporte generado con exito", "Exito,", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch(Exception ex) 
                {
                    MessageBox.Show("Error al generar el PDF"+ ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }

        }
    }
}
