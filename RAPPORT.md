# Rapport projet écosystème 2023

## Diagramme de classe

<picture>
 <img alt="Diagramme de classe" src="Diagramme_de_classe.png">
</picture>

## Diagramme de séquence

Le digramme de séquence ci-dessous est celui d'un herbivore. Nous avons seulement fait celui-ci car les autres entitées complexes se comportent de la même manière.

<picture>
 <img alt="Diagramme de séquence" src="Diagramme_séquence_Herbivore.png">
</picture>

## Principes SOLID:

### Ségrégation des interfaces:

Les modèles de notre code qui gèrent les entitées présentes dans l'écosystème hérites tous de une ou plusieurs interfaces et utilisent tous les paramètres et méthodes des interfaces dont ils héritent.

Par exemple: On veut un herbivore qui est une entité vivante capable de bouger, manger, se reproduire.
La classe Herbivore.cs hérite donc de IAbstractEntity, IAbstractLiving, IAbstractMoving mais n'héritera pas de IAbstractStatic qui contient des méthodes et de attributs plus spécifique aux plantes. Tous les paramètres et les méthodes de ces interfaces sont utiles à la classe.


### Principe de Liskov

Toute nos méthodes ont été codées avec les interfaces en paramètre mais on peut très bien passer une classe qui hérite d'une de ces interfaces.

Par exemple: La méthode Feed(IAbstractEntity entity) de IAbstractLiving prend en paramètre une IAbstractEntity, mais si on lui met une instance de Plant.cs en entrée, tout  fonctionnera perfaitement.

### PS

Il est possible d'ajuster les paramètres des entitées complexes en cliquant sur leur image dans la page des réglages.
Réglez les Pourcentages à plus de 100% à vos risques et périls :P 

