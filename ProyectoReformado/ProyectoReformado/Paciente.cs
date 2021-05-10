using System;
using System.Collections;
using System.Collections.Generic;

namespace ProyectoReformado
{
	public class Paciente
	{
		/********* ATRIBUTOS *********/
		
		private string _nom, _ape, _obraSocial;
		private int _dni, _nroAfiliado;
		private string _diag;
		private List<Paciente> _listaDiagnosticos = new List<Paciente>();
		private List<string> _listaObrasSociales = new List<string>();
		private List<string> listaAux = new List<string>();
		
		
		/********* MODIFICADORES DE ACCESO *********/
		
		public string Nombre{set {this._nom = value;} get{ return this._nom;} }
		public string Apellido{set {this._ape = value;} get{ return this._ape;} }
		public int Dni{set {this._dni = value;} get{ return this._dni;} }
		public string ObraSocial{set {this._obraSocial = value;} get{ return this._obraSocial;} }
		public int NroAfiliado{set {this._nroAfiliado = value;} get{ return this._nroAfiliado;} }
		public string Diag{set {this._diag = value;} get{ return this._diag;}}
		public List<Paciente> ListaDiagnosticos{set {this._listaDiagnosticos = value;} get {return this._listaDiagnosticos;}}
		public List<string> ListaObrasSociales{set {this._listaObrasSociales = value;} get {return this._listaObrasSociales;}}
		public List<string> ListaAux{set {this.listaAux = value;} get {return this.listaAux;}}		
		
		/********* CONSTRUCTOR *********/
		
		public Paciente(string nombre, string apellido, int dni, string obraSocial, int nroAfiliado)
		{
			this._nom = nombre;
			this._ape = apellido;
			this._dni = dni;
			this.ObraSocial = obraSocial;
			this._nroAfiliado = nroAfiliado;
		}
	
		public Paciente(string nombre, string apellido, int dni, string obraSocial, int nroAfiliado, string diagnosti)
		{
			this._nom = nombre;
			this._ape = apellido;
			this._dni = dni;
			this.ObraSocial = obraSocial;
			this._nroAfiliado = nroAfiliado;
			this._diag = diagnosti;
		}
		
		public Paciente(string nombre, string apellido, int dni)
		{
			this._nom = nombre;
			this._ape = apellido;
			this._dni = dni;
			this.ObraSocial = "Particular";
			this._nroAfiliado = 0;
		}
		
		// ******** METODOS *********/
		
		public void agregarDiag(Paciente dig){
			ListaDiagnosticos.Add(dig);
			Console.WriteLine("Diagnostico agregado!");
		}// FIN DE AGREGAR DIAGNOSTICO
		
		public void eliminarDiag(Paciente diag){
			if (ListaDiagnosticos.Count > 0) {
				for (int i = 0; i < ListaDiagnosticos.Count; i++) {
					if (ListaDiagnosticos[i].Diag == diag.Diag) {
						ListaDiagnosticos.RemoveAt(i);
						Console.WriteLine("DIAGNOSTICO ELIMINADO CON EXITO");
						break;
					}
				}	
			}else{Console.WriteLine("No hay pacientea a eliminar"); }
		} // FIN DE ELIMINAR DIAGNOSTICOS
		
		public void cantDiag(){
			
			Console.WriteLine("La cantidad de diagnosticos es de: " + ListaDiagnosticos.Count);
			
		}// FIN DE CANTIDAD DE DIAGNOSTICOS
		
		public void verListaDiag(){
			foreach (Paciente d in ListaDiagnosticos) {
				Console.WriteLine("\nPaciente {0} con dni {1}\nSu diagnostico es: {2}.\n", d.Nombre, d.Dni, d.Diag);
			}
		} // FIN DE VER LISTA DE DIAGNOSTICOS
		
		public void verUltimoDiag(){
			
			if (ListaDiagnosticos.Count > 0) {
				for (int i = 0; i < ListaDiagnosticos.Count; i++) {
					
					Console.WriteLine("El ultimo diagnostico es de {0}. Su diagnostico es de:\n{1}",
					                  ListaDiagnosticos[ListaDiagnosticos.Count-1].Nombre, 
					                 ListaDiagnosticos[ListaDiagnosticos.Count-1].Diag);
					break;
				}
			}else{
				Console.WriteLine("No hay diagnosticos disponibles");
			}
			
		} //FIN DE VER ULTIMO DIAGNOSTICO
		
		public void verListaDeObras(){
			foreach (string obra in ListaObrasSociales) {
				Console.WriteLine(") Obra social: {0}", obra);
			}
		}
		
		public void verListaAux(){
			foreach (string e in ListaObrasSociales) {
				if (!ListaAux.Contains(e)) {
					ListaAux.Add(e);
				}
			}
		}
		
		
		// ******** METODOS DE RESPALDO *********/
		
		public string getInfo(){	
			return "Nombre y apellido: " + Nombre + " " + Apellido + 
				"\nDNI: "+ Dni +
				"\nObra Social: " + ObraSocial.ToUpper() + " N° de afiliado: " + NroAfiliado + "\n\n********************\n";
		}
	}
}
