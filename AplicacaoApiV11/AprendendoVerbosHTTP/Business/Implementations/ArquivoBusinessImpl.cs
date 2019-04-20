using System.IO;

namespace AprendendoVerbosHTTP.Business.Implementations
{
    public class ArquivoBusinessImpl : IArquivoBusiness
    {
        public byte[] GetPDFFile()
        {
            string path = Directory.GetCurrentDirectory();
            string fullPath = path + "\\Files\\PDFInclude-PRO-Documentation.pdf";
            return File.ReadAllBytes(fullPath);
        }
    }
}
