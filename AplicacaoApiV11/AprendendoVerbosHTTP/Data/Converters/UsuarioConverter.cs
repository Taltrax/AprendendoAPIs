using System.Collections.Generic;
using AprendendoVerbosHTTP.Data.Converter;
using AprendendoVerbosHTTP.Data.VO;
using AprendendoVerbosHTTP.Model;
using System.Linq;

namespace AprendendoVerbosHTTP.Data.Converters
{
    public class UsuarioConverter : IParser<UsuarioVO, Usuario>, IParser<Usuario, UsuarioVO>
    {
        public Usuario Parse(UsuarioVO origin)
        {
            if (origin == null) return null;
            return new Usuario
            {
                Login = origin.Login,
                AccessKey = origin.AccessKey
            };
        }

        public UsuarioVO Parse(Usuario origin)
        {
            if (origin == null) return null;
            return new UsuarioVO
            {
                Login = origin.Login,
                AccessKey = origin.AccessKey
            };
        }

        public List<Usuario> ParseList(List<UsuarioVO> origin)
        {
            if (origin == null || origin.Count == 0) return null;
            return origin.Select(data => Parse(data)).ToList();
        }

        public List<UsuarioVO> ParseList(List<Usuario> origin)
        {
            if (origin == null || origin.Count == 0) return null;
            return origin.Select(data => Parse(data)).ToList();
        }
    }
}
