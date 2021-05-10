using System;
using System.Collections;
using System.Collections.Generic;

namespace ProyectoReformado
{
	class Program
	{
		public static void Main(string[] args)
		{
			Medico med = new Medico("Carlos", 23085610, 31274);
			
			Paciente pac1 = new Paciente("Ricardo", "Aguirre", 39556195, "osecac", 2456,"tos"); med.agregarPac(pac1);pac1.agregarDiag(pac1);
			Paciente pac2 = new Paciente("Micaela", "Moreyra", 40833889, "ioma", 6874, "asintomatico"); med.agregarPac(pac2);pac1.agregarDiag(pac2);
			Paciente pac3 = new Paciente("Pedro", "Ramirez", 14854326, "pami", 6348, "fiebre"); med.agregarPac(pac3);pac1.agregarDiag(pac3);
			
			
			// ********** MENU ****************//		
			
			int opcion = -1;
			
			do{
					Console.Clear();
					Console.WriteLine("MENU PRINCIPAL\n");
					
					Console.WriteLine("A continuacion elija la opcion que desee: ");
					
					Console.WriteLine("1) - Reservar turno");
					Console.WriteLine("2) - Atender turno");
					Console.WriteLine("3) - Cancelar turno");
					Console.WriteLine("4) - Agregar paciente");
					Console.WriteLine("5) - Eliminar paciente");
					Console.WriteLine("6) - Ver pacientes");
					Console.WriteLine("7) - Ver todos los diagnosticos");
					Console.WriteLine("8) - Ver todos los turnos");
					Console.WriteLine("9) - Ver lista de Obras Sociales");			
					Console.WriteLine("0) - Salir");	
					
					Console.Write("\nSeleccion: ");
				try
				{
					opcion = int.Parse(Console.ReadLine());
					Console.Clear();
					switch (opcion)
					{
						case 1: //Reservar turno <------
							Console.WriteLine("\n*** HOARIOS DE ATENCION DE 8:00 - 12:00 ***\n");
							Console.WriteLine("**** LOS TURNOS SON CADA 30 MINUTOS ****\n");
							med.listaDeTurnos();
							Console.WriteLine("");
							
							Console.Write("Ingrese el horario deseado(ejemplo: '8:00'): ");
							string mHora = Console.ReadLine();
							
							Console.Write("Ingrese el nombre del paciente: ");
							string mNombre = Console.ReadLine();
							Console.Write("Ingrese el Apellido: ");
							string mApellido = Console.ReadLine();
							Console.Write("Ingrese DNI(sin puntos): ");
							int mDni = int.Parse(Console.ReadLine());
							Console.Write("Posee Obra social(si/no): ");
							string confir = Console.ReadLine().ToUpper();
							if (confir == "SI" || confir == "S") {
								Console.Write("Nombre de obra social: ");
								string mObra = Console.ReadLine().ToUpper();
								Console.Write("Ingrese N° de afiliado: ");
								int mNroAfi = int.Parse(Console.ReadLine());
								Paciente pac = new Paciente(mNombre, mApellido, mDni, mObra, mNroAfi);
								med.agregarPac(pac);
							}else if (confir == "NO" || confir == "N") {
								Paciente pac = new Paciente(mNombre, mApellido, mDni);
								med.agregarPac(pac);
							}
							med.darTurno(mHora, mNombre);
							break;
						case 2: //Atender turno <------
							if (med.ContadorDeTurnos > 0) {
								antenderPaciente(med);
							}else{
								Console.WriteLine("No hay turnos por atender");
							}
							break;
						case 3: //Cancelar turno <------
							if (med.ContadorDeTurnos > 0) {
								Console.WriteLine("CANCELAR TURNO\n");
								med.totalTurnosOcupados();
								Console.Write("Ingrese el horario del turno a cancelar: ");
								string horaT = Console.ReadLine();
								med.cancelarTurno(horaT);
							}else{
								Console.WriteLine("No hay turnos para cancelar");
							}							
							break;
						case 4: //Agregar paciente <------
							Console.Write("Ingrese el nombre del paciente: ");
							mNombre = Console.ReadLine();
							Console.Write("Ingrese el Apellido: ");
							mApellido = Console.ReadLine();
							Console.Write("Ingrese DNI(sin puntos): ");
							mDni = int.Parse(Console.ReadLine());
							Console.Write("Posee Obra social(si/no): ");
							confir = Console.ReadLine().ToUpper();
							if (confir == "SI" || confir == "S") {
								Console.Write("Nombre de obra social: ");
								string mObra = Console.ReadLine().ToUpper();
								Console.Write("Ingrese N° de afiliado: ");
								int mNroAfi = int.Parse(Console.ReadLine());
								Paciente pac = new Paciente(mNombre, mApellido, mDni, mObra, mNroAfi);
								med.agregarPac(pac);
							}else if (confir == "NO" || confir == "N") {
								Paciente pac = new Paciente(mNombre, mApellido, mDni);
								med.agregarPac(pac);
							}							
							break;
						case 5: //Eliminar paciente <------
							Console.WriteLine("ELIMINAR PACIENTE\n");
							med.totalPac();
							Console.WriteLine("INGRESE LOS DATOS DEL PACIENTE A ELIMINAR\n");
							
							Console.Write("Ingrese el nombre del paciente: ");
							mNombre = Console.ReadLine();
							Console.Write("Ingrese el Apellido: ");
							mApellido = Console.ReadLine();
							Console.Write("Ingrese DNI(sin puntos): ");
							mDni = int.Parse(Console.ReadLine());							
							Paciente pa = new Paciente(mNombre, mApellido, mDni);
							med.eliminarPac(pa);
							
							break;
						case 6: //Ver pacientes <------
							med.todosPac();
							Console.Write("Ingrese el numeor del paciente que desee ver: ");
							int n = int.Parse(Console.ReadLine());
							string np = (string)med.verPaciente(n).Nombre;
							string ap = (string)med.verPaciente(n).Apellido;
							int dp = (int)med.verPaciente(n).Dni;
							string op = (string)med.verPaciente(n).ObraSocial;
							int nrop = (int)med.verPaciente(n).NroAfiliado;
							string dip = (string)med.verPaciente(n).Diag;
							Console.WriteLine("\nPaciente {0} {1} con dni {2}\n" +
							                  "Obra Social {3} con N° de afiliado {4}\n" +
							                  "Diagnostico: {5}", np.ToUpper(), ap.ToUpper(), dp, op.ToUpper(), nrop, dip);
							Console.Write("\nDesea modificar el diagnostico de {0}? s/n: ", np);
							string co = Console.ReadLine().ToLower();
							if (co == "s" || co == "si") {
								MenuDiagnostico(np, med);
							}
							break;
						case 7: //Ver todos los diagnosticos <------
							med.listaDiagnosticos();
							break;
						case 8:
							med.listaDeTurnos();
							break;
						case 9:
							med.listaObr();
							break;
					}//Fin del switch
/*fin del try*/		}catch (OverflowException) {Console.WriteLine("Ingrese un valor correcto");
					}catch(FormatException) {Console.WriteLine("Por favor ingrese un numero");
					}catch(Exception) {Console.WriteLine("A OCURRIDO UN ERROR INESPERADO");}
					Console.ReadKey(true);			
			}while (opcion != 0);			
		}
		
		public static void MenuDiagnostico(string noPac, Medico med){
			
			Console.Clear();
			Console.WriteLine("\nIngrese la opcion que desee:\n");
			Console.WriteLine("1) - Agregar diagnostico");
			Console.WriteLine("2) - Eliminar diagnostico");
			Console.WriteLine("3) - Volver al menu principal");
			
			try{			
				int elec = int.Parse(Console.ReadLine());		
					switch (elec) {
						case 1:
							Console.Write("Ingrese el nuevo diagnostico del paciente {0}: ", noPac);
							string nuevDiag = Console.ReadLine();
							nuevDiag = ", " + nuevDiag.Trim();
							foreach (Paciente p in med._ListaDePacientes) {
								for (int i = 0; i < p.ListaDiagnosticos.Count; i++) {
									if (p.ListaDiagnosticos[i].Nombre == noPac) {
										p.ListaDiagnosticos[i].Diag = p.ListaDiagnosticos[i].Diag.Insert(p.ListaDiagnosticos[i].Diag.Length, nuevDiag);
									}
								}
							}
							Console.WriteLine("\n\nDIAGNOSTICO ACTUALIZADO");
							break;
						case 2:
							Console.Write("Seguro que quiere eliminar el diagnostico? si/no: ");
							string con = Console.ReadLine().ToLower();
							if (con == "si" || con == "s") {
								foreach (Paciente p in med._ListaDePacientes) {
									for (int i = 0; i < p.ListaDiagnosticos.Count; i++) {
										if (p.ListaDiagnosticos[i].Nombre == noPac) {
											p.ListaDiagnosticos[i].Diag = p.ListaDiagnosticos[i].Diag.Remove(0, p.ListaDiagnosticos[i].Diag.Length);
											Console.WriteLine("\nDIAGNOSTICO ELIMINADO");
										}
									}
								}						
							}
							break;
					}
			}catch (OverflowException){Console.WriteLine("Ingrese un valor correcto");
			}catch(FormatException){Console.WriteLine("Por favor ingrese un numero");
			}catch(Exception){Console.WriteLine("A OCURRIDO UN ERROR INESPERADO");}
		}
		
		public static void antenderPaciente(Medico med){
			if (med.ContadorDeTurnos > 0) {
				try {
					med.totalTurnosOcupados();
					Console.Write("\nIngrese el numero del turno a atender: ");
					int atender = int.Parse(Console.ReadLine());
					string ocupNom = med.verTurno(atender).NombrePacTurno;
					string ocupHor = med.verTurno(atender).HoraTurno;
					Console.WriteLine("\nTurno de las {0} ocupado por {1}.", ocupHor, ocupNom.ToUpper());
					Console.WriteLine("\n****ATENCION EN CURSO*****\n\n");
					Console.Write("\nDesea actualizar el diagnostico? s/n: ");
					string condicion = Console.ReadLine().ToLower();
					if (condicion == "si" || condicion == "s") {
						MenuDiagnostico(ocupNom, med);
					}else{
						Console.WriteLine("\nATENCION FINALIZADA.");
					}
					
				} catch (FormatException) {
					Console.WriteLine("Debe ingresar un numero");
				}				
			}else{
				Console.WriteLine("No hay turnos reservados");
			}

		}// Terminar		
		
	}
}