using System;
using System.Collections;
using System.Collections.Generic;

namespace ProyectoReformado
{
	public class Medico
	{
		/********* ATRIBUTOS *********/
		
		private string  _nombre;
		private	int _dni, _matricula;
		private Turno[] TurnosDelDia;
		private List<Paciente>ListaDePacientes;
		private int contadorDeTurnos;
		
		
		/********* MODIFICADORES DE ACCESO *********/
		
		public string Nombre{set {this._nombre = value;} get{ return this._nombre;} }
		public int Dni{set {this._dni = value;} get{ return this._dni;} }
		public int Matricula{set {this._matricula = value;} get{ return this._matricula;} }
		public List<Paciente>_ListaDePacientes {set {this.ListaDePacientes = value;} get {return ListaDePacientes;}}
		public int ContadorDeTurnos{get {return contadorDeTurnos; }}
			
		
		/********* CONSTRUCTOR *********/
		public Medico(string nombre, int dni, int matricula)
		{
			this._nombre = nombre;
			this._dni = dni;
			this.contadorDeTurnos = 0;
			ListaDePacientes = new List<Paciente>();
			TurnosDelDia = new Turno[9];
			TurnosDelDia[0] = new Turno("8:00", "libre");
			TurnosDelDia[1] = new Turno("8:30", "libre");
			TurnosDelDia[2] = new Turno("9:00", "libre");
			TurnosDelDia[3] = new Turno("9:30", "libre");
			TurnosDelDia[4] = new Turno("10:00", "libre");
			TurnosDelDia[5] = new Turno("10:30", "libre");
			TurnosDelDia[6] = new Turno("11:00", "libre");
			TurnosDelDia[7] = new Turno("11:30", "libre");
			TurnosDelDia[8] = new Turno("12:00", "libre");
		}
		
		/********* METODOS *********/		
		
		public void darTurno(string unaHora, string nombrePac){
			try {
				foreach (Turno t in TurnosDelDia) {
					if (t.HoraTurno == unaHora && t.NombrePacTurno == "libre") {
						t.HoraTurno = unaHora;
						t.NombrePacTurno = nombrePac;
						contadorDeTurnos++;
						Console.WriteLine("\nTurno reservado para {0} a las {1}", nombrePac, unaHora);
					}else if (t.HoraTurno == unaHora && t.NombrePacTurno != "libre") {
						throw new SinTurnosException();
					}					
				}
			} catch (SinTurnosException) {
				Console.WriteLine("Horarios no disponibles o erroneo, llamar proximo dia de atencion");
			}
		}// FIN DE DAR TURNO
		
		public void cancelarTurno(string unaHora){
			if (contadorDeTurnos > 0) {
				for (int i = 0; i < TurnosDelDia.Length; i++) {
					if (TurnosDelDia[i].NombrePacTurno!="libre" && TurnosDelDia[i].HoraTurno==unaHora) {
						TurnosDelDia[i].NombrePacTurno="libre";
						Console.WriteLine("Turno de las {0} cancelado", unaHora);
						contadorDeTurnos--;
					}
				}			
			}else if (contadorDeTurnos == 0) {
				Console.WriteLine("No hay turnos para cancelar");
			}
		} // FIN  DE CANCELAR TURNO
		
		public void totalTurnosOcupados(){
			if (contadorDeTurnos > 0) {
				for (int i = 0; i < TurnosDelDia.Length; i++) {
					if (TurnosDelDia[i].NombrePacTurno!= "libre") {
						Console.WriteLine((i+1)+") Turno de las {0} se encuentra ocupado por {1}", TurnosDelDia[i].HoraTurno,
						                  TurnosDelDia[i].NombrePacTurno);
					}
				}
			}else if(contadorDeTurnos == 0){
				Console.WriteLine("No hay turnos ocupados");
			}

		} // FIN DE TOTAL DE TURNOS OCUPADOS
		
		public Turno verTurno(int i){
			if (contadorDeTurnos != 0 && contadorDeTurnos <= 9) {
				for (int t = 0; t < TurnosDelDia.Length; t++) {
					if (TurnosDelDia[i-1].NombrePacTurno != "libre") {
						return TurnosDelDia[i-1];
					}
				}
			}	
			return TurnosDelDia[i-1];
		} // FIN DE VER TURNO
		
		public void listaDeTurnos(){
			Console.WriteLine("\nLISTA DE TURNOS DEL DIA\n");
			Console.WriteLine("Turnos ocupados:\n");
			foreach (Turno t in TurnosDelDia) {
				if (t.NombrePacTurno != "libre") {
					Console.WriteLine("Turno de las {0} esta ocupado por {1}\n", t.HoraTurno, t.NombrePacTurno);
				}
			}
			
			Console.WriteLine("\nTurnos libres:\n");
			foreach (Turno tl in TurnosDelDia) {
				if (tl.NombrePacTurno == "libre") {
					Console.WriteLine("Turno de las {0} se encuentra {1}", tl.HoraTurno, tl.NombrePacTurno);
				}
			}
		} // Fin de lista de turnos
		
		public void agregarPac(Paciente unPac){
			bool existe = esPaciente(unPac);
			if (ListaDePacientes.Count > 0) {
				if (ListaDePacientes.Contains(unPac) == false && existe == false) {
					ListaDePacientes.Add(unPac);
					unPac.ListaObrasSociales.Add(unPac.ObraSocial.ToUpper());
				}else{
					Console.WriteLine("PACIENTE YA REGISTRADO");
				}
			}else{
				unPac.ListaObrasSociales.Add(unPac.ObraSocial.ToUpper());
				ListaDePacientes.Add(unPac);
			}
			
		} //FIN DE AGREGAR PACIENTE
		
		public void eliminarPac(Paciente unPac){
			if (ListaDePacientes.Count > 0) {
				for (int i = 0; i < ListaDePacientes.Count; i++) {
					if (ListaDePacientes[i].Dni == unPac.Dni && ListaDePacientes[i].Apellido == unPac.Apellido) {
						ListaDePacientes.RemoveAt(i);
						Console.WriteLine("PACIENTE REMOVIDO CON EXITO");
						break;
					}else if (ListaDePacientes[i].Dni != Dni && ListaDePacientes[i].Apellido == unPac.Apellido) {
						Console.WriteLine("ESTE PACIENTE NO EXISTE");
						break;
					}
				}
				
			}else{
				Console.WriteLine("No hay pacientea a eliminar");
			}
		} // FIN DE ELIMINAR PACIENTE
		
		public void totalPac(){
			Console.WriteLine("TOTAL DE PACIENTES: " + ListaDePacientes.Count);
			if (ListaDePacientes.Count > 0) {
				foreach (Paciente p in ListaDePacientes) {
					Console.WriteLine("\nPaciente {0} {1} con dni {2}\nObra social {3} con N° de afiliado {4}\n" +
					                  "Diagnostico: {5}" +
					                  "\n*************************************************************",
					                  p.Nombre, p.Apellido, p.Dni, p.ObraSocial.ToUpper(), p.NroAfiliado, p.Diag);
				}
			}else{
				Console.WriteLine("No hay pacientes registrados aun.");
			}
		} // FIN DE TOTAL PACIENTES
		
		public Paciente verPaciente(int i){
			for (int k = 0; k < ListaDePacientes.Count; k++) {
				return ListaDePacientes[i-1];
			}
			return ListaDePacientes[i-1];
		} // FIN DE VER TURNO
		
		public void todosPac(){
			if (ListaDePacientes.Count>0) {
				for (int i = 0; i < ListaDePacientes.Count; i++) {
					Console.WriteLine((i+1)+") " +ListaDePacientes[i].getInfo());
				}	
			}else{
				Console.WriteLine("Aun no hay pacientes registrados.\n");
			}
			
		} // FINDE TODOS LOS PACIENTES
		
		public bool esPaciente(Paciente unPac){
			if (ListaDePacientes.Count != 0) {
				for (int i = 0; i < ListaDePacientes.Count; i++) {
					if (ListaDePacientes[i].Dni == unPac.Dni) {
						return true;
					}
				}
			}
			return false;
		} // FIN DE ES PACIENTE
		
		
		/********* METODOS DE RESPALDO  *********/

		public void listaDiagnosticos(){
			if (ListaDePacientes.Count > 0) {
				foreach (Paciente t in ListaDePacientes) {
					t.verListaDiag();
					break;
				}				
			}else{
				Console.WriteLine("No hay diagnosticos guardados aun.");
			}
		}
		
		public void listaObr(){
			int conta = 1;
			Console.WriteLine("Obras registradas hasta el momento\n");
			foreach (Paciente d in _ListaDePacientes) {
				Console.Write(conta);
				d.verListaDeObras();
				conta++;
			}
		}

	} // FIN DE CLASS MEDICO
	
	
	/******** EXCEPCIONES *********/
	public class SinTurnosException : Exception
	{	
	}
	
	public class HoraIncorrectaException : Exception
	{
	}
	
}
