using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class FileVM: HttpPostedFileBase
    {
        public string fileName { get; set; }
        
        public FileVM()
        {

        }
        public FileVM(string s)
        {
            fileName = s;
        }
        public void GuardarArchivo(HttpPostedFileBase file,HttpServerUtilityBase server, GastoVM gasto)
        {
            string fileName = string.Format("{0} {1}", DateTime.Now.ToString("_MMddyyyy_HHmmss"), file.FileName);
            var path = Path.Combine(server.MapPath("~/Gastos/"), fileName);
            gasto.ArchivoComprobante = fileName;
            file.SaveAs(path);            
        }

        public void AltaDeArchivoComprobante(GastoVM gasto, HttpServerUtilityBase server)
        {
             //no cargo el archivo pero ya tenia uno
            if (gasto.fileComrobante == null && gasto.ArchivoComprobante != null)//tengo un archivo y el file es null -> no lo toco
            {
                HttpPostedFileBase FileBase = new FileVM(gasto.ArchivoComprobante);
                gasto.fileComrobante = FileBase;
            }
            else if (gasto.fileComrobante != null && gasto.ArchivoComprobante == null) //cargo un archivo y no habia cargado antes
            {
                GuardarArchivo(gasto.fileComrobante, server, gasto);
            }
            else if (gasto.fileComrobante != null && gasto.ArchivoComprobante != null) //cargo un archivo y tenia uno antes
            {
                GuardarArchivo(gasto.fileComrobante, server, gasto);
            }
        }
    }
}