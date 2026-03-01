# Unity2D\_CellialKiller-MedinaBastienGD2

Projet de cours pour le rendu sur le TD mobile en cours de moteur de jeu en GD2







**Intention du projet :**



-Contexte :

Player joue un vendeur de téléphone en faillite qui décide de détruire tout les autres magasins afin d'en récupéré les clients et de les faires fructifier pour son propre profit.



-Mini jeux :

 	-Type arcade : Le joueur arrive dans un magasin adverse. Il doit tuer le plus d'ennemis possibles puis s'enfuir. Chaque ennemis tué rapporte un certain nombre de score. Pour tuer, le joueur a plusieurs types d'armes : les téléphones qu'il peut(il a un bouton pour déclencher a sonnerie et faire imploser tout les ennemis toucher par un téléphone), des câbles (agissent comme un fouet). Il y a également plusieurs types d'ennemis : Les Body Guard (Très lent, beaucoup de dégâts), il y a aussi les Sellers(Très rapide, dégâts normaux. Si il ne reste moins d'un tiers de l'effectif initial, ils fuient le joueur). Enfin il y a un type de PNJ qui sont les clients : Ils fuient tous vers la sortie quand le joueur arrive. Le joueur doit essayer de ne pas les tuer pour qu'il y en ait un maximum qui s'enfuit.

 	-Type Game-and-Watch : Les clients qui se sont échapper du magasin s'enfuient vers le joueur sur 3 voie et le joueur doit en récolter le plus possible tout en essayant d'esquiver les mauvais payeur qui spawnerais de plus en plus vite et de plus en plus nombreux. Le joueur gagne quand tout les client qui se sont échapper sont apparu, et il perd s'il attrape 3 mauvais payeur.

 	-Type Gestion : Quand le joueur rentre dans son magasin, il peut mettre a profit les client qu'il a récupéré dans le jeu Game-and-Watch. ces client lui rapporte un revenu oscillant ne fonction du nombre ce qui lui permet d'acheter des améliorations pour sa boutique et ainsi avoir de nouvelles armes, de nouvelles capacité, etc.



Tout ces mini-jeu s'emboitent dans un boucle de gameplay qui les lient et sont tous complémentaire entre eux : Dans le jeu d'arcade, le joueur se bat avec les armes qu'il a acheter et qu'il a obtenue dans la jeu de gestion. Dans le jeu Game-and-Watch, la quantité de clients qui spawn sont les clients qui se sont échapper dans l'arcade multiplier par le score. Et enfin dans le jeu de gestion, ce sont les clients obtenus dans la Game-and-Watch qui lui rapporte des revenu et qui lui permettent les améliorations et les armes pour l'arcade.



-Style Graphique :

Les graphismes de ce jeu seront en 2D pixel art et en noir et blanc. Il y a peu de touche de couleurs. L'environnement es très simple alors que les personnages eux sont plus détailler mais restent en noir et blanc. Cette DA est inspiré du jeu Undertales qui reprend certains de ces trais et notamment dans les personnages.



-Intention de jeu :

Ce jeu est très satisfaisant a jouer car il y a beaucoup de feedbacks de types caméra Shake et courte animation. De plus la violence général du gameplay ajoute du dynamisme au jeu ce qui accroit la tension du joueur et ainsi sa satisfaction de jeu.







**Premier rendu (02/03/2026) :**



-Jeux réaliser :

 	-Type arcade : Ennemis, téléphone et visuel similaire a l'intention. Le joueur n'a qu'une seul arme qui est le téléphone.

 	-Type Game-and-Watch : jeu similaire a l'intension



-Mécaniques en cours :

 	-Système de High score : A la fin de chaque mini-jeu, le score et récupéré et ajouter a un scriptable Object. Si il y a déjà un score sur ce mini-jeu d'enregistré, on vérifie si le nouveau score est supérieur a l'ancien et si c'est le cas, il devient le nouveau meilleur high score qui est afficher dans le menu principal.



-Améliorations envisagé pour prochain rendu :

 	-Ajouter son

 	-Améliorer les environnement de level en ajoutant des props en rapport avec le lieu (bureau, présentoir, etc)

 	-Rebonds de téléphone

 	-Transition Win/Loose



