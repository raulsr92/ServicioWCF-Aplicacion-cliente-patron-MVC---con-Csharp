using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF_Matriculas
{
    internal class MetodosReutilizablesCurso
    {
        public static List<CursoDC> getLista(IQueryable<Tb_Cursos> query)
        {
            List<CursoDC> lista = new List<CursoDC>();

            foreach (var item in query)
            {
                CursoDC objCursoDC = new CursoDC();

                objCursoDC.Cod_Cur = item.Cod_Cur;
                objCursoDC.Des_Cur = item.Des_Cur;
                objCursoDC.Cred_Cur = Convert.ToInt16(item.Cred_Cur);
                objCursoDC.Usu_Reg = item.Usu_Reg;
                objCursoDC.Fec_Reg = Convert.ToDateTime(item.Fec_Reg);
                objCursoDC.Usu_Ult_Mod = item.Usu_Ult_Mod;
                objCursoDC.Fec_Ult_Mod = Convert.ToDateTime(item.Fec_Ult_Mod);
                objCursoDC.Est_Curso = Convert.ToInt32(item.Est_Cur);

                if (objCursoDC.Est_Curso == 1)
                {
                    objCursoDC.Estado = "Activo";
                }
                else
                {
                    objCursoDC.Estado = "Inactivo";
                }

                lista.Add(objCursoDC);
            }

            return lista;
        }


        public static CursoDC procesarCurso(Tb_Cursos objCursoEncontrado)
        {
            CursoDC objCursoDC = new CursoDC();

            if (objCursoEncontrado != null)
            {
                objCursoDC.Cod_Cur = objCursoEncontrado.Cod_Cur;
                objCursoDC.Des_Cur = objCursoEncontrado.Des_Cur;
                objCursoDC.Cred_Cur = Convert.ToInt16(objCursoEncontrado.Cred_Cur);
                objCursoDC.Usu_Reg = objCursoEncontrado.Usu_Reg;
                objCursoDC.Fec_Reg = Convert.ToDateTime(objCursoEncontrado.Fec_Reg);
                objCursoDC.Usu_Ult_Mod = objCursoEncontrado.Usu_Ult_Mod;
                objCursoDC.Fec_Ult_Mod = Convert.ToDateTime(objCursoEncontrado.Fec_Ult_Mod);
                objCursoDC.Est_Curso = Convert.ToInt32(objCursoEncontrado.Est_Cur);

                if (objCursoDC.Est_Curso == 1)
                {
                    objCursoDC.Estado = "Activo";
                }
                else
                {
                    objCursoDC.Estado = "Inactivo";
                }
            }

            return objCursoDC;
        }
    }
}
