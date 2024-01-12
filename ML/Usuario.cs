using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Usuario
    {



        public int IdUsuario { get; set; }


        [Required]
        [StringLength(50, ErrorMessage = "demasiados caracteres")]
        [DisplayName("UserName")]
        [RegularExpression(@"[A-Za-z0-9]{0,50}$", ErrorMessage ="Caracteres no validos para nombre de usuario")]
        public string UserName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "desmasiados caracteres")]
        [DisplayName("Nombre")]
        [RegularExpression(@" ^([A-Za-zÁÉÍÓÚñáéíóúÑ]{0}?[A-Za-zÁÉÍÓÚñáéíóúÑ\']+[\s])+([A-Za-zÁÉÍÓÚñáéíóúÑ]{0}?[A-Za-zÁÉÍÓÚñáéíóúÑ\'])+[\s]?([A-Za-zÁÉÍÓÚñáéíóúÑ]{0}?[A-Za-zÁÉÍÓÚñáéíóúÑ\'])?$  ", ErrorMessage = "Caracteres no validos para nombre")]

        public string Nombre { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "desmasiados caracteres")]
        [DisplayName("ApellidoPaterno")]
        [RegularExpression(@"^[A-Za-z][A-Za-z0-9_]{2,50}$", ErrorMessage = "Caracteres no validos para Apellido Paterno")]

        public string ApellidoPaterno { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "desmasiados caracteres")]
        [DisplayName("ApellidoMaterno")]
        [RegularExpression(@"^[A-Za-z][A-Za-z0-9_]{2,50}$", ErrorMessage = "Caracteres no validos para Apellido Materno")]

        public string ApellidoMaterno { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "desmasiados caracteres")]
        [DisplayName("Email")]
        [RegularExpression(@"/^(([^<>()\[\]\\.,;:\s@”]+(\.[^<>()\[\]\\.,;:\s@”]+)*)|(“.+”))@((\[[0–9]{1,3}\.[0–9]{1,3}\.[0–9]{1,3}\.[0–9]{1,3}])|(([a-zA-Z\-0–9]+\.)+[a-zA-Z]{2,}))$/", ErrorMessage = "Caracteres no validos para Email")]


        public string Email { get; set; }

        public string Pasword { get; set; }

        public string Sexo { get; set; }

        public string Telefono { get; set; }

        public string Celular { get; set; }

        public string FechaNacimiento { get; set; }

        public string CURP { get; set; }

        public ML.Rol Rol { get; set; }

        public List<Object> Usuarios { get; set; }

        public byte[] Imagen { get; set; }

        public ML.Direccion Direccion { get; set; }

        public bool Estatus { get; set; }

    }
}
