# MRFinalProject

Este demo es un proyecto de Realidad virtual que pretende introducir un tipo de movimiento, saltando, como alternativa a algunos ya existentes como Teleporting y movimiento continuo con Joystick. Este tipo de movimiento pretende lograr que no se corte la inmersión al desplazarse y que tampoco genere sintomas de MotionSickeness o al menos los disminuya en gran medida. Se establecieron 3 diferentes escenarios con diversas caracteristicas en las que se puede probar los tres tipos de movimeintos mencionados anteriormente.  Para el desarrollo de este proyecto VR se uso Unity y corre en Oculus Rift y Quest. 
<img width="915" alt="Captura de Pantalla 2021-12-12 a la(s) 9 52 47 p  m" src="https://user-images.githubusercontent.com/53877876/145745102-2478a6cb-ed62-4b66-a4e6-6e6e6adaf4da.png">
<img width="903" alt="Captura de Pantalla 2021-12-12 a la(s) 9 53 58 p  m" src="https://user-images.githubusercontent.com/53877876/145745107-8b824e83-0255-4f51-8d7b-b42340355cbf.png">

## Pre-requisitos 

Se debe instalar Unity Hub y la versión de Unity 2020.3.17. Además de Visual Studio para la edición de los scripts. Por último tener la aplicación de Oculus para poder probar por medio de Oculus link los cambios en el proyecto. 

## Instrucciones para desarrollo 

1. Clonar el proyecto en su computador. Git clone https://github.com/NicolasAbo17/MRFinalProject.git
2. Abrir Unity Hub -> Add y seleccionar el proyecto clonado.
3. Elegir la versión de Unity correspondiente, en este caso la 2020.3.17.

## Instrucciones uso del ejecutable

Al ejecutar el programa, primero el usuario aparecera en un "home". Para activar el menú de opciones se debe mantener presionado el botón secundario izquierdo (Y) y con el ray derecho y el grip seleccionar las opciones deseadas. El primer botón "escenarios" abrira un segundo menú con los escenarios disponibles. Al darle en el botón "Enter" se dirigirá al escenario deseado. El segundo botón del menú resetea la medida de la altura del casco que se usa para el movimiento de salto. Finalmente con el último botón podrá cambiar entre los diferentes tipos de moviemientos disponibles. Todos los movimientos se activan con el joystick llevandolo hacia adelante. En el caso de movimiento con salto se apunta al lugar al que quiere desplazarse y cuando salte, se movera al lugar indicado. Con el movimiento con teleportación, se apunta al lugar y con el grip se indica cuando se quiere mover hacia dicho lugar. Finalmente, con el movimiento continuo se mueve con el joystick izquierdo como cualquier videojuego. El menú principale de opciones se puede abrir en cualquier momento en cualquie escena. 


