using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataEntities;
using DataAccess;
using Common;


namespace BussinesLogic
{
    public class Seguridad
    {
        private apuestasEntities context = null;

        public Seguridad()
        {
            context = BLAbstract.Instance.Context;
        }
        
        public usuario Autenticacion(string User, string pwd)
        {
            string e = Utilidades.EncryptKey("3157");
            string d = Utilidades.DecryptKey(e);
            string password = Utilidades.EncodePassword(User + pwd);
            return context.usuario.Where(u => u.UserName == User && u.Contraseña == password && u.Estado==true).FirstOrDefault();
        }

        public void Guardar(usuario u)
        {
            context.usuario.AddObject(u);
            context.SaveChanges();
        }

        public bool UsuarioExiste(string UserName)
        {
            return context.usuario.FirstOrDefault(u => u.UserName == UserName) != null;
        }

        public usuario ObtenerUsuarioporId(Guid Id)
        {
            return context.usuario.FirstOrDefault(u => u.Id == Id);
        }

        public Guid UltimaVenta(Guid Id)
        {
            return context.usuario.FirstOrDefault(u => u.Id == Id).IdUltimaVenta.Value;
        }

        public List<usuario> ObtenerUsuarios()
        {
            return context.usuario.ToList();
        }

        public decimal CupoDisponible(Guid idUsuario)
        {
            return context.usuario.FirstOrDefault(u => u.Id == idUsuario).CupoDiario.Value;
        }

        public decimal CupoDisponibleEntidad()
        {
            return context.entidad.FirstOrDefault().CupoDisponible.Value;
        }

        public void Actualizar(usuario u)
        {
            context.usuario.ApplyChanges(u);
            context.SaveChanges();
        }

        public List<perfiles> ObtenerPerfiles()
        {
            return context.perfiles.ToList();
        }
        
        public perfiles ObtenerPerfilporId(Guid idPerfil)
        {
            return context.perfiles.Include("menu").FirstOrDefault(p => p.Id == idPerfil);
        }

        public entidad ObtenerEntidad()
        {
            return context.entidad.FirstOrDefault();
        }

        public void ActualiarCupoEntidad(entidad e)
        {
            context.entidad.ApplyChanges(e);
            context.SaveChanges();
        }

        public void EliminarMenu(Guid idUsuario)
        {
            List<menu> L = context.usuario.FirstOrDefault(u => u.Id == idUsuario).menu.ToList();
            foreach (menu m in L)
            {
                context.usuario.FirstOrDefault(u => u.Id == idUsuario).menu.Remove(m);
                context.SaveChanges();
            }
        }
    }
}
