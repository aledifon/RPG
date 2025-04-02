Hola, me llamo Bea. ¿Eres nuevo en el pueblo?
No me suenas de nada...

-> elecciones

== elecciones
¿Que debería decir?
    +[Ser borde] -> chosen("- Que chafarderos sois en este pueblo, illo. No se puede dar dos pasos sin que te interroguen... -")
    +[Ser amable] -> chosen("- Hola, me llamo Roberto y soy nuevo en el pueblo. Me alegro de conocerte, Bea. -")
    +[...] -> chosen("- ... -")
    
== chosen(decisionesRoberto)    

{decisionesRoberto}

Oye, quería pedirte un favor... He perdido mi libro favorito... Bueno... Creo que mi hermano pequeño me lo ha escondido...

Suele esconder las cosas en cofres que ve por el pueblo... ¿Podrías buscarlo por mí?

-> recaderosFTW

== recaderosFTW
¿Qué debería hacer?
    +[Ayudarla] -> chosen2("- Claro, yo te ayudo sin problema. -")
    +[Ser borde] -> chosen2("- ¡YA ESTAMOS CON LAS MISIONES DE RECADERO! Odio cuando en un videojuego me obligan a ser el tío de los recaos... -")
    +[...] -> chosen2("- ... -")


== chosen2(recados)
{recados}

-> END