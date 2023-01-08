# Rapport projet écosystème 2023



## Principes SOLID:

### Ségrégation des interfaces:

Les modèles de notre code qui gèrent les entitées présentes dans l'écosystème hérites tous de une ou plusieurs interfaces et utilisent tous les paramètres et méthodes des interfaces dont ils héritent.

Par exemple: On veut un herbivore qui est une entité vivante capable de bouger, manger, se reproduire.
La classe Herbivore.cs hérite donc de IAbstractEntity, IAbstractLiving, IAbstractMoving mais n'héritera pas de IAbstractStatic qui contient des méthodes et de attributs plus spécifique aux plantes. Tous les paramètres et les méthodes de ces interfaces sont utiles à la classe.
