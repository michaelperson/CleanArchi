# DOMAIN LAYER OU CORE LAYER

![Onion](./Ressources/Layer.png)

**Domain (avec les règles business) est la couche la plus importante**

Partie la plus INTERNE de l'oignon (pas de dépendances avec d'autres couches).

Contient :
* Entities
* Use cases (combinent les données de 1 ou plusieurs Repository Interface)
* Repository Interfaces 

**Domain Layer ne dépend pas du Data Layer.**

![Dépendances](./Ressources/Dépendance.png)