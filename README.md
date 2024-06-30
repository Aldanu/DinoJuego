# Introduction 
Videojuego para el concurso para desarrollar el “Dino Juego” del Ministerio de Gobierno. Aplicación móvil en el cuál se 
apoya a el personaje Dino a luchar contra la criminalidad, enseñar a los niños y niñas sobre la seguridad.
https://www.vision360.bo/noticias/2024/06/19/6579-lanzan-un-concurso-para-desarrollar-el-dino-juego-cuyo-personaje-debera-luchar-contra-la-delincuencia

# Getting Started
1.	Descargar repositorio
2.	Godot versión 4.0.0 o superior
3.	Se usa C# para los scripts
4.	La escena principal del proyecto se ubica en Levels/Main.tscn

# Build and Test
TODO: Describe and show how to build your code and run the tests. 

# Contribute
La jerarquia de archivos tiene el siguiente formato:
- addons: Contiene los plugins externos para el funcionamiento del proyecto
- Entities: Guarda las entidades del jugador, enemigos y NPCs. Aqui se guardan los scripts y assets en conjunto con la escena a la que pertenecen
- Levels: Guarda las escenas de los niveles con sus scripts y assets especificos.
- Resources: Guarda los recursos que son usados en diversos lugares o por diversas escenas, guarda singletons, shaders que se usan
en varias escenas, clases.
- UI: se guarda interfaces de usuario

Ejemplo de jerarquia dentro de cada carpeta:
- Levels/levelTest/
  - Level_script
  - Level_scene
  - Level_texture
  - Level_specific_shaders/
