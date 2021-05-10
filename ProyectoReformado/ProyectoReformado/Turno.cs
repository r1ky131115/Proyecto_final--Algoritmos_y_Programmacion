using System;
using System.Collections;
using System.Collections.Generic;

namespace ProyectoReformado
{
	public class Turno
	{
		/********* ATRIBUTOS *********/
		
		private string _nombrePac;
		private string _hora;
		
		/********* MODIFICADORES DE ACCESO *********/
		
		public string NombrePacTurno{set {this._nombrePac = value;} get{ return this._nombrePac;} }
		public string HoraTurno{set {this._hora = value;} get{ return this._hora;} }
		
		
		/********* CONSTRUCTOR *********/
		
		public Turno(string hora, string nombrePac)
		{
			this._nombrePac = nombrePac;
			this._hora = hora;
		}
	}
}
