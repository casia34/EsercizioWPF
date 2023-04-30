using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercizioWPF.Models
{
    public interface IPersonaService
    {
        IList<Persona> Persone { get; }
    }

    public class PersonaServices : IPersonaService
    {
       private List<Persona> _persona = null;
        public PersonaServices()
        {

            _persona = new List<Persona>();

            _persona.Add(new Persona() { Nome = "Mario", Cognome = "Rossi" });

            _persona.Add(new Persona() { Nome = "Giovanni", Cognome = "Bianchi" });

            _persona.Add(new Persona() { Nome = "Leonardo", Cognome = "Bianini" });

        }
       public IList<Persona> Persone => _persona;
    }
}
