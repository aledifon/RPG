Bea: Hola, me llamo Bea. ¿Eres nuevo en el pueblo?
Bea: No me suenas de nada...

-> elecciones

== elecciones
    +[Ser borde] -> chosen("Roberto: Que chafarderos sois en este pueblo, illo. No se puede dar dos pasos sin que te interroguen...")
    +[Ser amable] -> chosen("Roberto: Hola, me llamo Roberto y soy nuevo en el pueblo. Me alegro de conocerte, Bea.")
    +[...] -> chosen("Roberto: ...")
    
== chosen(decisionesRoberto)    
 
{decisionesRoberto}

Bea: Oye, quería pedirte un favor... He perdido mi libro favorito... Bueno... Creo que mi hermano pequeño me lo ha escondido...

Bea: Suele esconder las cosas en cofres que ve por el pueblo... ¿Podrías buscarlo por mí?

-> recaderosFTW

== recaderosFTW
    +[Ayudarla] -> chosen2("Roberto: Claro, yo te ayudo sin problema.")
    +[Ser borde] -> chosen2("Roberto: ¡YA ESTAMOS CON LAS MISIONES DE RECADERO! Odio cuando en un videojuego me obligan a ser el tío de los recaos...")
    +[...] -> chosen2("Roberto: ...")


== chosen2(recados)
{recados}

-> END