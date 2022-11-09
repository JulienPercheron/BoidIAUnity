### Projet IA (Boids & Machine a etats finis) Julien Percheron - M2 Gamagora, 2022

---

Petit jeu sur Unity implementant des boids avec un comportement défini par une Machine a etats finis.<br /> 
Les 3 états sont "free roam", "target objective" et "controlledByPlayer".<br /> <br /> 
Les boids démarrent en "free roam", puis au bout de 5s, un objectif apparait et tous les boids passent en etat "target objective". Dans cet etat, les boids, en plus de leur comportement normal, se dirigent vers l'objectif qui vient d'apparaitre. Quand l'objectif est touché, il disparait et tous les boids reviennent en free roam. Au bout de 5s l'objectif reapparait la boucle recommence.<br /> <br /> 
Il est possible d'appuyer sur clic gauche pour prendre le contrôle d'un boid (il devient rouge). On le deplace avec ZQSD ou les fleches directionnelles.<br /> 
La couleur des boids change selon leur etat.<br /> <br /> 
Le score est incrementé a chaque fois qu'un boid touche l'objectif. Lorsque ce score atteint 5 le joueur a gagné. Le temps qu'il a mis a atteindre ces 5 points représente score. <br /> 

Les boids ont été réalisés en partie à partir de la suite de tutoriels suivants : https://www.youtube.com/playlist?list=PL5KbKbJ6Gf99UlyIqzV1UpOzseyRn5H1d
