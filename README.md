# Proyecto_final--Algoritmos_y_Programmacion
Proyecto que refleja la agenda para un medico


Un médico tiene registrada la información de los turnos dados en el día: nombre paciente y hora de 
la cita (string hh:mm). Los turnos los da cada media hora, entre las 8 y las 12hs(horario del ultimo 
turno). Además tiene almacenada la información de cada uno de sus pacientes: nombre, dni, obra 
social (“particular” si no posee), nro de afiliado a la obra social (0 si no posee obra social), lista de 
diagnósticos.
En aplicación debe crear un médico, crear algunos pacientes y cargarlos a la lista de pacientes. 
Luego implementar las funciones necesarias para responder a los ítems del menú.

Las clases a definir son:
  Médico: nom y ape, dni, array de los 9 turnos del dia , arrayList de pacientes
  Turno: nombre paciente y hora (Si el nombre de paciente está en blanco es porque el turno 
    está libre. También se puede agregar atributo estado y cuando se ocupa el turno se carga el 
    nombre del paciente.)
  Paciente: nombre y ape, dni, obra social, nro afiliado, lista de diagnósticos

Métodos:
  
  Medico → métodos
  
  Constructor crea la lista de pacientes vacía y el array de turnos con hora asignada y nombre de 
  paciente en “ “ (eso indica si el turno esta libre o ocupado)
  Propiedades para atributos: nombre, dni y matricula (set y get)
  darTurno(string unaHora,string nombrePac) ocupa el turno asignándole el nombrePac
  cancelarTurno(string unaHora) libera el turno de esa hora poniendo nombre paciente en “ “
  totalTurnosOcupados()
  verTurno(i) retorna el turno i-esimo
  listaDeTurnos() retorna el array de turnos 
  agregarPac(Paciente unPac)
  eliminarPac(Paciente unPac)
  totalPac()
  verPac(j) retorna el paciente j-esimo
  todosPac() retorna la lista de pacientes
  esPaciente(Paciente unPac) retorna V o F si unPac ya es paciente o no del médico

Turno → métodos
  Constructor
  Propiedades para los atributos: nombrePac, hora (set y get)
Paciente → métodos
  Constructor
  Propiedades para los atributos: nom y ape, dni, obra social, nro afiliado (set y get)
  agregarDiag(diag)
  eliminarDiag(diag)
  cantdiag()
  verListaDiag() retorna la lista de diagnósticos
  verUltimoDiag() retorna el ultimo diagnostico guardad
