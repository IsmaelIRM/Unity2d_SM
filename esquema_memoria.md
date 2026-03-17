# Anotaciones sobre como se ha hecho el juego


## Terreno

* Se crea un objeto Tilemap, con la herramienta de *tiles* se crea un dibujo de las plataformas. A partir de ese dibujo se crea el terreno de plataformas.
* Una vez creado el terreno, se selecciona el objeto *tilemap* de la jerarquía y se le añade un componente *Tilemap Collider 2D*, de ese modo el terreno deja de ser solo un dibujo y pasa a ser una estructura sólida con físicas y por tanto colisiones.
* Se cambia la capa del *tilemap* a **Ground** para que posteriormente se pueda detectar que el jugador está en contacto con el suelo.
* Añadir un componente Composite Collider 2D, en el Collider 2D que genera cambiar el Body Type de dinámico a estático para evitar que el nivel caiga por la gravedad. Se define la operacion del composite a merge para evitar que el jugador tropiece con la superficie.

## Jugador

* Se crea el jugador inicialmente como un cuadrado. Se cambia el sprite de este a uno importado. Además se le añaden animaciones (idle, run, disparo, etc...) con la herramiento de animación
* Se le añade un script de movimiento. Este debe controlar si el jugador está tocando el suelo, para ello se crea un objeto vacío hijo del jugador que estará comprobando si eljugador toca el suelo.
  * El objeto vacío (*GroundCheck*) tiene su componente y en -0.1, para que quede justo debajo de los pies del jugador, con posición por defecto en y=0

## Cámara

* En vez de crear un script para la cámara, se descarga el paquete de *Cinemachine*.
* Se crea un objeto Cinemachine camera 2D. A este se le define *Trcking* *Target* al objeto del jugador, de este modo la cámara lo seguirá.