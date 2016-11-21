using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace GenerateurXml
{
    [XmlRoot("personnage")]
    public class Perso
    {
        [XmlAttribute("id")]
        public int Id;
        [XmlAttribute("key")]
        public string Key;
        [XmlAttribute("nom")]
        public string Nom;
        [XmlElement("biographie")]
        public string Biographie;
        [XmlAttribute("idLogo")]
        public int IdLogo;
        [XmlArray("listeSon")]
        [XmlArrayItem("son")]
        public List<Son> ListeSon;
        [XmlArray("listeCategorie")]
        [XmlArrayItem("categorie")]
        public List<Categorie> ListeCategorie;
    }

    [XmlRoot("son")]
    public class Son
    {
        [XmlAttribute("id")]
        public int Id;
        [XmlAttribute("text")]
        public string Text;
        [XmlAttribute("raccourci")]
        public string Raccourci;
        [XmlAttribute("categorie")]
        public int IdSousCategories;
        [XmlAttribute("sonCourt")]
        public bool SonCourt;
    }

    [XmlRoot("categorie")]
    public class Categorie
    {
        [XmlAttribute("id")]
        public int Id;
        [XmlAttribute("text")]
        public string Text;
    }


    public static class Program
    {
        static void Main(string[] args)
        {
            //BIOGRAPHIE
            var bioAnnonceur = new StringBuilder();
            bioAnnonceur.Append("L'Annonceur joue un petit rôle dans Portal 2. Il guide le joueur à travers le centre avec des messages préenregistrés dans les premiers stades du jeu, avant le réveil de GLaDOS. Il rassure le joueur à travers les salles de test en ruine en le considérant comme un être d'avenir.");
            bioAnnonceur.Append("L'Annonceur fait de nombreuses suppositions quant à l'état du Centre d'enrichissement délabré. Ces messages préenregistrés sont conçus pour toutes les situations possibles comme pour une pluie de météorite ou un monde gouverné par un nuage doué de conscience. ");
            bioAnnonceur.Append("\r\nLe retrouvant dans de nombreux endroits du jeu, le rôle général de l'Annonceur serait d'assurer la maintenance d'Aperture Science, et même si il nous parle d'une voix apaisante, ces annonces susciteraient bien souvent la panique chez le sujet de test.");
            bioAnnonceur.Append("L'Annonceur dispose aussi d'une palette d'actions préprogrammées, mais dont l'utilisation nécessite la plupart du temps une intervention humaine.Une tâche simple tel que l'extinction d'un incendie est dans ses cordes, mais lorsqu'il s'agit d'empêcher la fusion du cœur du réacteur ou réaliser un transfert de processeurs lorsque l'un d'eux est corrompu et opposé à ce transfert, l'Annonceur a besoin d'une manœuvre humaine pour s'exécuter. ");

            var bioAventure = new StringBuilder();
            bioAventure.Append("La Sphère Aventure, s'appelant elle-même Rick, est un Processeur de Personnalité d'un programmme mâle apparaissant pour la première fois dans Portal 2. Il s'agit d'un des processeurs que GLaDOS envoie à Chell pour attacher à Wheatley, pour initier la procédure de Transfert de Cœur.");
            bioAventure.Append("La Sphère Aventure s'expire comme le stéréotype d'un dur, passant le plus clair de son temps à fanfaronner à propos de son courage et de son attirance pour le danger. Lorsqu'il voit Chell, il commence à flirter avec, en faisant des commentaires de plus en plus chauvins. Il essaie même (en pure perte) de convaincre Chell de prendre un moment pour se remaquiller pendant qu'il s'occupe de Wheatley lui-même. ");

            var bioEspace  = new StringBuilder();
            bioEspace.Append("La Sphère Espace est un Processeur de Personnalité corrompu d'un programme mâle, qui apparait pour la première fois dans Portal 2. Il est le premier des trois processeurs corrompus attachés à Wheatley par Chell dans le but d'initier une procédure de transfert de cœur.");
            bioEspace.Append("La Sphère Espace parle de manière hyperactive, parlant constamment de son obsession pour l'Espace et qu'elle veut un jour y aller. Pourtant, il y a une petite portion de ses répliques qui disent qu'elle en a marre de l'Espace et qu'elle voudrait rentrer sur Terre. Son rêve se réalise lorsqu'elle est aspiré à travers le portail qui l'envoie elle et Wheatley dans l'Espace. ");

            var bioInfo = new StringBuilder();
            bioInfo.Append("La Sphère-Info est un Processeur de Personnalité qui apparait pour la première fois dans Portal 2. Il s'agit d'un des processeurs que GLaDOS envoie à Chell pour attacher à Wheatley, pour initier la procédure de Transfert de Cœur.");
            bioInfo.Append("La Sphère-Info s'exprime comme un M. Je-sais-tout stéréotype, passant la plupart de son temps à débiter diverses informations. Si une partie de ces informations est vraie, la plupart sont incorrectes voir complètement fausses. ");

            var bioTurretDef = new StringBuilder();
            bioTurretDef.Append("Les Tourelles Défectueuses, nommées comme étant des 'Tourelles Nazes' par Wheatley, sont incomplètes, une version sans munition des Tourelles Mitrailleuses. Les Tourelles Défectueuses ont aussi un sens de l'humour et du sarcasme plus prononcés. Elles parlent dans une voix plus masculine et moins robotique.");
            bioTurretDef.Append("Elles sont inoffensives pour Chell et font des commentaires du genre 'Si quelqu'un demande, je vous ai tuée'. Elles sont censées êtres aveugles, mais elles sont au courant de la présence de Chell. ");

            var bioTurret = new StringBuilder();
            bioTurret.Append("Les Tourelles Mitrailleuses sont des robots tripodes présents dans la série Portal. Elles sont incapables de bouger toutes seules mais elles peuvent ouvrir leurs 'bras' à chaque côté de leur corps qui révèlent deux mitrailleuses Gatling. La partie principale de leur corps possède un œil rouge qui émet un laser de visée.");
            bioTurret.Append("Quand le joueur est loin des tourelles, celles-ci sont en 'mode veille' et gardent leurs bras rétractés. Aller dans leur champ de vision active le 'mode mitrailleuse'. Elles ouvrent donc leurs bras et tirent à vue jusqu'à que le joueur soit mort ou qu'il sorte de leur vision. Dans le dernier cas, les tourelles scannent une dernière fois la zone, et si le joueur ne s'y trouve pas, elles se remettent en mode veille.");
            bioTurret.Append("\r\nLes Tourelles peuvent être évitées, désactivées ou détruites de plusieurs façons. La manière la plus classique de le faire est de la renverser avec le Générateur de Portails ou un autre objet, ce qui la fera tirer une dernière rafale de balles avant de passer en 'mode hibernation'. On peut aussi avoir l'aide des Lasers Thermodécourageants ou des Grilles d’Émancipation pour détruire complètement les Tourelles. ");

            var bioWheatley = new StringBuilder();
            bioWheatley.Append("Durant le jeu, Wheatley aide Chell à échapper aux tests de GLaDOS. Ils arrivent à saboter la ligne de production des Tourelles et le Générateur de Neurotoxine de GLaDOS avant de l'affronter face-à-face. Arrive alors une procédure de transfert de cœur et Wheatley prend alors le contrôle du complexe. Alors qu'il s'apprête à permettre à Chell de quitter le centre, il se fait corrompre par la puissance et le pouvoir, devenant de ce fait l'adversaire principal du jeu. Wheatley implémente alors GLaDOS dans une patate et envoie par accident, elle et Chell, dans les vieilles salles de test oubliées, dans les profondeurs d'Aperture Science.");
            bioWheatley.Append("Après être revenu des anciennes salles de test, Chell et GLaDOS apprennent que les actions de Wheatley cause au réacteur du complexe d'approcher de la fusion nucléaire. Après avoir traversé de nouvelles salles de test fabriquées par Wheatley, il essaie de tuer Chell et GLaDOS. Après avoir échappé à son piège, GLaDOS suggère qu'elles devraient essayer de causer un nouveau transfert de cœur en implantant des Processeurs corrompus à Wheatley.");
            bioWheatley.Append("Chell entre dans le repaire de Wheatley pour l'affrontement final du jeu. En arrêtant temporairement Wheatley à l'aide des bombes qu'il lui envoie, Chell arrive à le corrompre pour initier une nouvelle procédure de transfert de cœur, sauvant le complexe de la destruction en cours. Pourtant une temporisation arrive lorsque Wheatley n'accepte pas d'être transféré, Chell doit alors appuyer sur le bouton de résolution des temporisations pour finaliser le transfert. Mais Wheatley avait piégé le bouton avec des explosifs, et Chell se retrouve éloignée du bouton. Elle survit et lance un portail sur la surface de la Lune, lui causant d'être aspirée avec Wheatley dans l'espace. GLaDOS récupère alors son ancien corps et sauve Chell abandonnant Wheatley au vide spatial.");
            bioWheatley.Append("\r\nWheatley est vu pour la dernière fois dans l'épilogue après le générique, avec la Sphère Espace orbitant autour de lui, racontant qu'il souhaite dire à Chell à quel point il est désolé de ce qu'il lui a fait subir. ");
            bioWheatley.Append("\r\nWheatley, aussi connu par GLaDOS comme la Sphère Cognitoréductrice dans Portal, est un Processeur de Personnalité d'un programme mâle avec un accent britannique de l'ouest. Il apparait pour la première fois dans Portal 2. Il est le guide de Chell dans la première partie du jeu, l'aidant à s'enfuir du complexe d'Aperture Science. ");

            var bioGlados = new StringBuilder();
            bioGlados.Append("GLaDOS, abréviation de Genetic Lifeform and Disk Operating System (Forme de Vie Génétique et Système d’Exploitation de Disque), est une intelligence artificielle dédiée à contrôler et superviser les laboratoires d'Aperture Science, mais elle est aussi l'administratrice du Centre d’Enrichissement assisté par ordinateur d'Aperture Science. Elle devient l'alliée de Chell dans la seconde moitié de Portal 2 et supervise les tests d'Atlas et de P-Body lors de la campagne co-op. Elle a la capacité de changer et de déplacer les installations et les chambres de tests, rendant les possibilités de conception des chambres de tests presque infinies et les transitions entre les salles sans coupures. ");
            bioGlados.Append("La première apparition de GLaDOS date de 1982 (comme on peut le voir dans un texte du premier ARG de Portal) où elle est alors à sa version 1.09 et surveille les sujets de test dans le jeu Portal. Aperture a d'abord utilisé un système de babillage électronique dès 1973, qui sera ensuite remplacé par GLaDOS en 1997.");
            bioGlados.Append("En 1986, la construction de GLaDOS commence dans le but d'accélerer le projet Portal et de battre leur rival Black Mesa. Un premier prototype de châssis pour GLaDOS est construit mais il fût abandonné par la suite. En 1996, après une décennie, est créé le Système d'Exploitation de Disque avec un système de fonctionnement plus ou moins basique, les travaux commencent.");
            bioGlados.Append("\r\n\r\nCave Johnson et Caroline");
            bioGlados.Append("\r\nCave Johnson devait à l'origine être la personne qui devait servir à créer la personnalité de la Forme de Vie Génétique. Malheureusement, il mourrut avant de pouvoir être transféré. Il a laissé pour instruction de transférer son assistante Caroline à sa place. On ne sait pas si Caroline accepta d'être transférée ou si elle fût forcée par les scientifiques");
            bioGlados.Append("Pour sécuriser le Centre d'Enrichissement, un système de surveillance nommé Aperture Science Red Phone fût créé. Il consistait à un téléphone rouge placé à l'entrée de la Chambre de GLaDOS et qui devait servir au cas où GLaDOS soit douée d'une sensation de puissance. En 1997, GLaDOS est à sa version 3.11.");
            bioGlados.Append("Quelques temps avant Mai 200-, GLaDOS fût activée à plusieurs reprises par des techniciens d'Aperture, mais elle fût rapidement éteinte après avoir tenté de les tuer 'un seizième de picoseconde après avoir été allumée'. Sans être découragés, les scientifiques tentèrent de modifier la personnalité de GLaDOS 'et lutter contre ses tendances meurtrières' en branchant des processeurs de moralité à son système. Plusieurs de ces processeurs furent désactivés puis placés dans un entrepôt. On ne sait pas si cela a été fait par les scientifiques après qu'ils se soient avérés non-efficaces ou par GLaDOS qui a voulu se débarrasser de la plupart d'entre eux.");
            bioGlados.Append("\r\nFinalement, GLaDOS affirma 'avoir perdu toute envie de tuer' et vouloir travailler sur la conscience. Elle annonça qu'elle voulait réaliser une expérience en utilisant des chats et des boîtes. Elle affirma qu'elle avait tous les matériaux nécessaires mais qu'il lui manquait 'juste un peu de neurotoxine'. Les scientifiques consentirent 'du moment que c'est pour la science'.");
            bioGlados.Append("Enfin, en Mai 200-, GLaDOS atteint sa version finale lors de la journée annuelle d'Aperture 'Emmenez votre fille à votre journée de travail'. En une picoseconde, GLaDOS redevint hostile et dans la picoseconde qui suivit, elle verrouilla tous les accès au Centre d'Enrichissement, piégeant tout le monde à l'intérieur puis déversa de la neurotoxine dans tout le Centre. Les survivants lui fixèrent un processeur de moralité, ce qui empêcha GLaDOS de se servir à nouveau de neurotoxine sans pour autant stopper toutes ses envies meurtrières.");
            bioGlados.Append("GLaDOS commença alors un cycle d'essais avec les employés d'Aperture Science en captivité dans le but de dépasser Black Mesa dans la course à la téléportation. Elle perdit cette course, cependant, lorsque les incidents de Black Mesa se produisirent, GLaDOS détourna son attention de garder les employés d'Aperture. Pendant ce temps, le nombre d'employés à Aperture Science diminua lors des semaines qui suivirent les tests. Le dernier employé vivant fût un programmeur schizophrène nommé Doug Rattman qui réussit à s'échapper grâce à sa paranoïa. Il réussit à accéder aux fichiers personnels des sujets de test et découvrit un femme nommé Chell qui fût rejetée des tests à cause de sa grande ténacité. Espérant qu'elle réussisse à détruire GLaDOS, il trafiqua alors la liste des sujets de test et la placa en tête de liste. Cela semblait passer inaperçu pour GLaDOS. Après cela, Rattman se cacha dans une zone du Centre que GLaDOS ne pouvait pas surveiller. Elle recommença alors les tests. ");
            bioGlados.Append("Des décennies se sont passées entre la fin de Portal et le début de Portal 2. GLaDOS restant inconsciente durant toute cette période, les systèmes automatiques et les processeurs tentèrent de maintenir le Centre en état de marche sans les conseils de GLaDOS. Elle affirmera plus tard qu'une 'boîte noire' dans son système a gardé sa conscience dans une boucle sans fin des deux dernières minutes avant sa destruction. Chell est finalement réveillé par Wheatley. Avec lui, elle parcourt les salles de tests détériorées mais la maladresse de Wheatley va réveiller GLaDOS. Celle-ci montre une profonde amertume envers Chell. Elle blesse Wheatley et envoie Chell faire d'autres salles de test pendant qu'elle restaure le Centre d'Enrichissement.");
            bioGlados.Append("Wheatley survit à ses blessures et permet à Chell de s'échapper mais GLaDOS parvient de nouveau à les piéger et les ramène dans sa nouvelle Chambre qu'elle a reconstruit avec l'intention de les tuer.");
            bioGlados.Append("\r\n\r\nGLaDOS dans sa nouvelle chambre.");
            bioGlados.Append("\r\nCependant, elle découvre que Chell et Wheatley ont saboté la ligne de production de tourelles et son générateur de neurotoxine. Ils réussissent à déclencher un transfert de noyaux, c'est à dire débrancher GLaDOS de l'ordinateur principal pour la remplacer par Wheatley. Jubilant, Wheatley célèbre sa nouvelle puissance et l'humiliation de GLaDOS en l'attachant à une batterie de pomme de terre capable d'alimenter uniquement sa conscience et ses fonctions élémentaires. Toute fois, GLaDOS n'est pas totalement impuissante. Elle parvient à mettre Wheatley en colère qui se retourne alors contre Chell dans un excès de rage et de paranoïa. Furieux, il s'attaque à Chell et à GLaDOS et les envoie dans les entrailles du Centre d'Enrichissement.");
            bioGlados.Append("GLaDOS, dans une pomme de terre, sera emporté par un oiseau puis retrouvée par Chell. Désespérée, elle s'associe à Chell pour vaincre Wheatley. Chell empale GLaDOS sur le générateur de Portail ce qui lui fournit un peu plus de puissance que la pomme de terre. Comme ils se trouvent dans les anciennes salles de test d'Aperture Science, des messages pré-enregistrées de Cave Johnson et de son assistante Caroline se déclenchent. GLaDOS réagit à ces deux voix mais elle est d'abord incapable de se rappeler pourquoi ces deux voix lui sont familières. Elle tombe alors dans un silence pendant un certain temps, disant à Chell qu'elle doit réfléchir sur certaines choses. Finalement, la raison de sa réaction émotionnelle devient claire et elle commence à se souvenir des ses origines et retrouve des pensées de Caroline dans ses souvenirs. Elle explique alors qu'elle possède une sorte de conscience ce qu'elle prétend trouver gênant et désagréable.");
            bioGlados.Append("Chell et GLaDOS finissent finalement à retourner dans les installations modernes d'Aperture Science. L’incompétence de Wheatley crée une menace grave pour le centre d'enrichissement qui va se dégrader jusqu'à une probable explosion du coeur du réacteur. GLaDOS tente de le désactiver mais cela est sans effet et Wheatley les force alors à effectuer des salles de tests. GLaDOS et Chell effectuent plusieurs salles puis réussissent à s'échapper de la 'surprise' de Wheatley et s'enfuient dans le Centre. GLaDOS élabore alors un plan, elle fournit à Chell des processeurs corrompus qu'elle attache à Wheatley pour pouvoir effectuer un nouveau transfert de noyau. Toutefois, Wheatley déclencha un piège lors du transfert. Alors que le centre est sur le point de s'auto-détruire, Chell est à terre à cause du piège. Le plafont tombe, montrant la lune. Chell tire un portail alors sur l'astre. Chell et Wheatley sont aspirés dans l'espace. Profitant de cette instant, GLaDOS reprend le contrôle du centre et éjecte Wheatley dans l'espace. Étonnamment, GLaDOS rattrape Chell inconsciente et la met en sécurité dans le Centre d'Enrichissement après avoir fermé le portail.");
            bioGlados.Append("Après cela, GLaDOS répare le Centre d'Enrichissement. Lorsque Chell se réveille, GLaDOS exprime son soulagement et lui dit que, si autrefois elle la considérait comme sa pire ennemie, elle se rend compte finalement qu'elle est sa plus grande amie. Elle ajoute ensuite que ces émotions positives lui ont permis de retrouver la personnalité de Caroline dans sa base de données. GLaDOS semble alors supprimer ces fichiers pour redevenir la sociopathe qu'elle était avant. Toutefois, GLaDOS explique que si elle veut se débarrasser de Chell une fois pour toutes, la façon la plus simple est tout simplement de la libérer. Elle met Chell dans un ascenseur qu'elle fait remonter à la surface en lui répétant de ne jamais revenir. Chell sort dans un champ de blé ensoleillé. GLaDOS prend également la décision de lui rendre son Cube de Voyage Lesté qu'elle avait incinéré dans Portal.");
            bioGlados.Append("Après la libération de Chell, GLaDOS commence les tests coopératifs avec ses deux robots, Atlas et P-Body. Elle leur a préparé quatre zones de test et dès les premier tests, les deux robots commencent à montrer des émotions et des gestes typiques aux humains. Cela rend GLaDOS mécontente mais elle reste patiente. A la fin du premier parcours de test, GLaDOS envoie, de façon inattendue, Atlas et P-Body en dehors des parcours de test standard. Elle leur indique juste que cette épreuve se passe en dehors des parcours standards et qu'elle ne peut pas dire en quoi elle consiste. Les deux robots arriveront au cours de ceux tests, dans une salle avec un vidéoprojecteur projetant le texte 'Ne lui faites pas confiance.'. Etant donné que les deux robots ne peuvent pas avoir de pensées, ils ignorent l'avertissement. Après avoir trouvé un disque et l'avoir inséré dans un ordinateur, ce qui accorde secrètement à GLaDOS une nouvelle partie du Centre d'Enrichissement, elle leur révèle que le seul moyen de les ramener à la surface est de les détruire puis de les reconstruire. Elle précise également qu'ils ne peuvent pas ressentir la douleur.");
            bioGlados.Append("\r\nFinalement, GLaDOS exprimera une forme d'ennui car tester les robots est moins satisfaisant que de tester des humains qui, eux, ressentent la peur et peuvent mourir. Après chaque parcours, GLaDOS envoie systématiquement Atlas et P-Body hors des parcours de tests, se servant d'eux comme des sbires sans même qu'ils ne le sachent. Ces tests hors des salles de tests ont pour objectif de former les deux robots et de prendre petit à petit le contrôle total du Centre d'Enrichissement. Après avoir déclaré qu'elle 'pouvait tout voir', elle envoie les deux robots dans un parcours de test inédit dans les profondeurs d'Aperture Science, dans un arbre de test inconnu datant des années 50 à 70. Elle a en réalité réussit à trouver des sujets de tests humains en cryostase à la fin de ce parcours. Elle révélera au deux robots qu'elle est incapable de ressentir la moindre satisfaction à leur réussite ce qui rend les sujets humains indispensable à ses yeux. Elle révèle également que les envoyer au début du parcours leur permet de les former aux problèmes qui les attendront à proximité du lieu où se trouvent les sujets de test.");
            bioGlados.Append("Quand les deux robots arrivent à leur objectif, l'endroit est fermé par une porte qui ne peut être ouverte qu'avec une intervention humaine. GLaDOS force donc les deux robots à ouvrir la porte. Ils y arrivent et pénètrent dans une immense salle où se trouve des centaines voire même des milliers de sujets de test en cryostase prolongée. Mais si ils sont plus sujets à des lésions cérébrales comme le fût peut-être Chell, GLaDOS récupère tous les sujets de tests en les analysant un par un comme le montre le générique du mode coopératif.");
            bioGlados.Append("Plus tard, dans le DLC Peer Review, GLaDOS reconstruit Atlas et P-Body et leur affirme que 100 000 ans se sont écoulés et que les humains sont tous vivants et qu'ils vont bien. Puis elle les envoie à une 'thérapie par l'art' qui se compose de nouvelles sallse de test. Mais, à la fin de la quatrième salle de tests, la machine de démontage tombe en panne, obligeant GLaDOS a laisser tomber ses deux robots dans les profondeurs du Centre d'Enrichissement. Elle admet qu'en réalité elle a menti et que seulement deux semaines se sont écoulées. Elle déclare après qu'un intrus inconnu s'est installé dans un des vieux châssis de GLaDOS se trouvant dans les vieilles installations d'Aperture Science, et qu'il prend le contrôle du centre ce qui explique le problème de la machine de démontage. GLaDOS leur explique aussi qu'elle a envoyé les sujets de test humains pour chasser l'intrus. Elle voulait d’ailleurs les transformer en machines à tuer. Elle a donc envoyé les robots qu'elle essaie également de transformer en machines à tuer en leur disant toutes sortes de conseils.");
            bioGlados.Append("\r\nFinalement, les deux robots atteignent le châssis de GLaDOS et découvrent que l'intrus est en réalité l'oiseau qui avait kidnappé GLaDOS dans la campagne solo de Portal 2 et qui a fait son nid dans le châssis. Cependant, souffrant d'une phobie pour les oiseaux, GLaDOS exagère les capacités de l'oiseau et conseille aux robots de battre en retraite. Toutefois, Atlas s'approche de l'oiseau et après un petit moment de panique, l'oiseau s'enfuit hors des installations et P-Body ferme alors les accès. GLaDOS panique en voyant que le nid contient des œufs et elle ordonne à Atlas et à P-Body de les détruire, mais finalement, elle change d'avis et décide de couver les œufs. Trois poussins vont naitre et GLaDOS va en nommer un monsieur Bec Potelé. Alors qu'elle se moque de son grand bec, celui ci va briser le verre derrière lequel il se trouve. GLaDOS se rend alors compte qu'ils sont des machines à tuer parfaites. Elle leur demande d'aller dormir, en précisant qu'elle a de grands projets pour le lendemain. ");
            
            var bioCave = new StringBuilder();
            bioCave.Append("Cave Johnson est le fondateur de Aperture Science, lequel a évolué depuis son précurseur, Aperture Science Innovators. Cave Johnson est apparu pour la première fois comme référence dans une chambre cachée dans Portal puis obtint une apparence et des détails supplémentaires durant le ARG Portal. Dans Portal 2, Cave Johnson devient un personnage important et communique avec le joueur par le biais d'une multitude de messages automatiques pré-enregistrés. Son état et ses activités sont actuellement inconnus, mais il est présumé mort, à cause de son exposition au produit toxique qu'il a créé à partir de roches lunaires raffinées. ");
            bioCave.Append("\r\n\r\nRideaux de Douche");
            bioCave.Append("\r\nEn 1953, Cave Johnson crée Aperture Fixtures, une fabrique de Rideaux de Douche. Le précurseur de Aperture Science, il sélectionna le nom puisque celui-ci 'faisait sonner les rideaux comme plus hygiéniques'. Il devint milliardaire après avoir remporté un contrat pour la confection des rideaux de douche de l'Armée Américaine.");
            bioCave.Append("\r\n\r\nAperture Science Innovators");
            bioCave.Append("\r\nDurant sa carrière scientifique, il appela les riches et les puissants à rejoindre sa cause pour le futur de la science. Il employa aussi les meilleurs scientifiques et membres de personnel dans leurs champs, comme Caroline, ou aussi les personnes manquants de sens commun pour faire face aux dangers inhérents à l'expérimentation scientifique. La plupart de ses idées étaient folles, et bien souvent, létales. Certaines expériences pouvaient impliquer le remplacement du sang du sujet de test par de l'essence, alors que d'autres étaient exposés à des moteurs de jet pour diminuer le montant d'eau dans le corps humain. La seconde expérience fût réalisée après que Cave Johnson ait conclut que la quantité moyenne d'eau dans le corps humain 'semblait excessive'. La plupart de ses idées folles se révélèrent être d'énormes échecs, laissant uniquement quelques unes paraissant utiles, comme les gels apparaissant à un stade ultérieur du jeu.");
            bioCave.Append("\r\n\r\nAperture");
            bioCave.Append("\r\nAu moment de sa création, Aperture Science Innovations a développé le Aperture Science Portable Quantum Tunneling Device (l'Outil Portable de Tunnel Quantique d'Aperture Science), un prototype du Générateur de Portail moderne utilisé par Chell. Ainsi, il semble qu'Aperture avait déjà commencé à perfectionner la technologie des portails, mais n'était pas prêt à le sortir au grand public, à cause de l'idée qu'on pouvait faire autre chose que juste créer des portails. Bien sur, la technologie était imparfaite et volumineuse, et fût repoussée à cause de l'imagination débridée de Cave. Durant les années 1970, Aperture Science était connu simplement sous le nom 'Aperture', et la montée de Black Mesa et de son succès pour récupérer les contrats, tapa bien sur les nerfs de Cave. C'est à ce moment que Caroline devint une partie importante dans la vie de Cave en tant que secrétaire, et que celui-ci devient plus désespéré dans la lutte pour continuer son travail, en offrant par exemple des récompenses à ses sujets de test, bien qu'ils ne puissent que rarement la récupérer suite aux dangers des tests.");
            bioCave.Append("\r\n\r\nAperture Laboratories");
            bioCave.Append("\r\nÀ un certain moment dans les années 1980, Cave Johnson renomma sa compagnie Aperture Laboratories, un nom qui sera connu loin dans le futur. Pourtant, le nombre de sujets de test volontaires a fondu avec les années, et par désespoir, les employés et même le premier étranger venu sorti de la rue, sont utilisés pour prendre part aux tests. La technologie ayant bien avancé, les robots ont remplacé les employés humains. Ces humains sont devenus les pauvres victimes de Cave dans sa quête pour le futur de la Science.");
            bioCave.Append("Dans ses derniers jours, Cave annonce avoir essayé d'acheter un bon nombre de 'roches lunaires'. Pourtant ses derniers enregistrements indiquent que ces roches sont toxiques, causant une maladie mortelle. Il expliqua qu'il a contracté sa maladie lorsque dans une de ses idées folles, il a moulu ensemble les roches lunaires pour en faire un nouveau type de substance appelé le 'Gel Conversif', probablement nommé ainsi grace à sa capacité de servir de conducteur de portail et permettre d'en placer sur n'importe quelle surface. Au fur et à mesure que ses symptômes deviennent plus graves, il décide d'utiliser le gel conversif avec l'espoir qu'il aspire le poison hors de son système.");
            bioCave.Append("Sa tentative pour se soigner est un échec et avec aussi ses espoirs de guérison, il ordonne alors à ses ingénieurs de commencer à faire des recherches sur l'Intelligence artificielle (IA) et la Cartographie Cérébrale dans l'espoir que son esprit pourra être téléchargé dans un ordinateur. Cave a aussi dit que 'Ça fait trente ans qu'on aurait dû se concentrer [dessus]'. De peur qu'il meure avant la mise au point de cette technologie, il laissa des instructions que sa secrétaire, Caroline, prenne la tête de Aperture Science. Il disait qu'il savait que 'Elle va rechigner. C'est son genre', poursuivant en précisant 'Je ne veux pas le savoir, forcez-lui la main'. On peut donc présumer que Caroline fût sélectionnée pour sa dévotion au progrès scientifique, un trait de caractère admiré par Cave, ainsi que sa relation privilégiée avec le Fondateur d'Aperture. Il est impossible de savoir ce qu'est devenu Cave, mais on pense qu'il est décédé victime des suites de sa maladie en stade terminal, pour la science. ");

            //PERSONNAGES

            //Cave
            var cave = new Perso
            {
                ListeCategorie = new List<Categorie>(),
                ListeSon = new List<Son>(),
                Id = 0,
                Key = "cave",
                Nom = "Cave Johnson",
                IdLogo = 3,
                Biographie = bioCave.ToString()
            };
            cave.ListeCategorie.Add(new Categorie { Id = 1, Text = "Annes 50" });
            cave.ListeCategorie.Add(new Categorie { Id = 2, Text = "Annes 70" });
            cave.ListeCategorie.Add(new Categorie { Id = 3, Text = "Annes 80" });
            cave.ListeCategorie.Add(new Categorie { Id = 4, Text = "Divers" });

            cave.ListeSon.Add(new Son { Id = 1, IdSousCategories = 1, Raccourci = "cave1", Text = "Bienvenue chez Aperture", SonCourt = false });
            cave.ListeSon.Add(new Son { Id = 2, IdSousCategories = 1, Raccourci = "cave2", Text = "Je m'appelle Cave Johnson.", SonCourt = true });
            cave.ListeSon.Add(new Son { Id = 3, IdSousCategories = 1, Raccourci = "cave3", Text = "Les tests qui vous sont attribués.", SonCourt = false });
            cave.ListeSon.Add(new Son { Id = 4, IdSousCategories = 1, Raccourci = "cave4", Text = "La science est batie", SonCourt = false });
            cave.ListeSon.Add(new Son { Id = 5, IdSousCategories = 1, Raccourci = "cave5", Text = "Les gars du labo", SonCourt = false });
            cave.ListeSon.Add(new Son { Id = 6, IdSousCategories = 1, Raccourci = "cave6", Text = "Element classifié", SonCourt = true });
            cave.ListeSon.Add(new Son { Id = 7, IdSousCategories = 1, Raccourci = "cave7", Text = "Non, pas vous, le cobaye.", SonCourt = true });
            cave.ListeSon.Add(new Son { Id = 8, IdSousCategories = 1, Raccourci = "cave8", Text = "Félicitations !  ", SonCourt = false });
            cave.ListeSon.Add(new Son { Id = 9, IdSousCategories = 1, Raccourci = "cave9", Text = "By bye Caroline", SonCourt = true });
            cave.ListeSon.Add(new Son { Id = 10, IdSousCategories = 2, Raccourci = "cave10", Text = "Qui veut gagner 60 dollars?", SonCourt = true });
            cave.ListeSon.Add(new Son { Id = 11, IdSousCategories = 2, Raccourci = "cave11", Text = "Ascenseur, pas pissotière", SonCourt = true });
            cave.ListeSon.Add(new Son { Id = 12, IdSousCategories = 2, Raccourci = "cave12", Text = "Dissection", SonCourt = true });
            cave.ListeSon.Add(new Son { Id = 13, IdSousCategories = 3, Raccourci = "cave13", Text = "Durée de vie des cobayes", SonCourt = false });
            cave.ListeSon.Add(new Son { Id = 14, IdSousCategories = 3, Raccourci = "cave14", Text = "La vie", SonCourt = false });
            cave.ListeSon.Add(new Son { Id = 15, IdSousCategories = 3, Raccourci = "cave15", Text = "Fin du test", SonCourt = true });
            cave.ListeSon.Add(new Son { Id = 16, IdSousCategories = 4, Raccourci = "cave16", Text = "rire", SonCourt = true });
            cave.ListeSon.Add(new Son { Id = 17, IdSousCategories = 4, Raccourci = "cave17", Text = "Amiante", SonCourt = false });

            //Glados
            var glados = new Perso
            {
                ListeCategorie = new List<Categorie>(),
                ListeSon = new List<Son>(),
                Id = 1,
                Key = "glados",
                Nom = "Glados",
                IdLogo = 2,
                Biographie = bioGlados.ToString()
            };
            glados.ListeCategorie.Add(new Categorie { Id = 1, Text = "Campagne" });
            glados.ListeCategorie.Add(new Categorie { Id = 2, Text = "Coop" });
            glados.ListeCategorie.Add(new Categorie { Id = 3, Text = "Patate" });
            glados.ListeCategorie.Add(new Categorie { Id = 4, Text = "Tests" });

            glados.ListeSon.Add(new Son { Id = 1, IdSousCategories = 4, Raccourci = "glados1", Text = "Super déco", SonCourt = false });
            glados.ListeSon.Add(new Son { Id = 2, IdSousCategories = 1, Raccourci = "glados2", Text = "Bye bye caroline", SonCourt = true });
            glados.ListeSon.Add(new Son { Id = 3, IdSousCategories = 1, Raccourci = "glados3", Text = "Je suis géniale", SonCourt = false });
            glados.ListeSon.Add(new Son { Id = 4, IdSousCategories = 1, Raccourci = "glados4", Text = "Club des vivants", SonCourt = true });
            glados.ListeSon.Add(new Son { Id = 5, IdSousCategories = 1, Raccourci = "glados5", Text = "vous capturez était simple", SonCourt = false });
            glados.ListeSon.Add(new Son { Id = 6, IdSousCategories = 1, Raccourci = "glados6", Text = "Je vous hais cordialement", SonCourt = true });
            glados.ListeSon.Add(new Son { Id = 7, IdSousCategories = 1, Raccourci = "glados7", Text = "Nononononon", SonCourt = true });
            glados.ListeSon.Add(new Son { Id = 8, IdSousCategories = 1, Raccourci = "glados8", Text = "Un cerf", SonCourt = false });
            glados.ListeSon.Add(new Son { Id = 9, IdSousCategories = 3, Raccourci = "glados9", Text = "Je n'essai pas de vous berner", SonCourt = false });
            glados.ListeSon.Add(new Son { Id = 10, IdSousCategories = 3, Raccourci = "glados10", Text = "Maudit oiseau", SonCourt = true });
            glados.ListeSon.Add(new Son { Id = 11, IdSousCategories = 3, Raccourci = "glados11", Text = "On a compris merci", SonCourt = true });
            glados.ListeSon.Add(new Son { Id = 12, IdSousCategories = 3, Raccourci = "glados12", Text = "Mort au petit cochon", SonCourt = true });
            glados.ListeSon.Add(new Son { Id = 13, IdSousCategories = 3, Raccourci = "glados13", Text = "Je suis une patate", SonCourt = true });
            glados.ListeSon.Add(new Son { Id = 14, IdSousCategories = 3, Raccourci = "glados14", Text = "Eh abruti", SonCourt = true });
            glados.ListeSon.Add(new Son { Id = 15, IdSousCategories = 3, Raccourci = "glados15", Text = "Ah l'oiseau, tuez le !", SonCourt = true });
            glados.ListeSon.Add(new Son { Id = 16, IdSousCategories = 4, Raccourci = "glados16", Text = "Surprise à l'issu des tests", SonCourt = false });
            glados.ListeSon.Add(new Son { Id = 17, IdSousCategories = 4, Raccourci = "glados17", Text = "La comédie", SonCourt = false });
            glados.ListeSon.Add(new Son { Id = 18, IdSousCategories = 4, Raccourci = "glados18", Text = "Sous alimentation", SonCourt = false });
            glados.ListeSon.Add(new Son { Id = 19, IdSousCategories = 4, Raccourci = "glados19", Text = "Performances satisfaisantes", SonCourt = false });
            glados.ListeSon.Add(new Son { Id = 20, IdSousCategories = 2, Raccourci = "glados20", Text = "Vous trouvez ça drôle?", SonCourt = false });
            glados.ListeSon.Add(new Son { Id = 21, IdSousCategories = 2, Raccourci = "glados21", Text = "Insensible à la douleur", SonCourt = false });
            glados.ListeSon.Add(new Son { Id = 22, IdSousCategories = 2, Raccourci = "glados22", Text = "Récompense", SonCourt = false });
            glados.ListeSon.Add(new Son { Id = 23, IdSousCategories = 2, Raccourci = "glados23", Text = "Bravo", SonCourt = true });

            //Wheatley
            var wheatley = new Perso
            {
                ListeCategorie = new List<Categorie>(),
                ListeSon = new List<Son>(),
                Id = 2,
                Key = "wheatley",
                Nom = "Wheatley",
                IdLogo = 2,
                Biographie = bioWheatley.ToString()
            };
            wheatley.ListeCategorie.Add(new Categorie { Id = 1, Text = "Allié" });
            wheatley.ListeCategorie.Add(new Categorie { Id = 2, Text = "Ennemi" });

            wheatley.ListeSon.Add(new Son { Id = 1, IdSousCategories = 1, Raccourci = "wheatley1", Text = "Le folklore humain", SonCourt = false });
            wheatley.ListeSon.Add(new Son { Id = 2, IdSousCategories = 2, Raccourci = "wheatley2", Text = "Non, que dalle", SonCourt = true });
            wheatley.ListeSon.Add(new Son { Id = 3, IdSousCategories = 2, Raccourci = "wheatley3", Text = "Enfin une adversaire", SonCourt = false });
            wheatley.ListeSon.Add(new Son { Id = 4, IdSousCategories = 1, Raccourci = "wheatley4", Text = "Eh oh", SonCourt = true });
            wheatley.ListeSon.Add(new Son { Id = 5, IdSousCategories = 2, Raccourci = "wheatley5", Text = "Adorer la surprise", SonCourt = false });
            wheatley.ListeSon.Add(new Son { Id = 6, IdSousCategories = 2, Raccourci = "wheatley6", Text = "Voilà, c'est réparé", SonCourt = true });
            wheatley.ListeSon.Add(new Son { Id = 7, IdSousCategories = 2, Raccourci = "wheatley7", Text = "Je ne suis pas un abruti!", SonCourt = true });
            wheatley.ListeSon.Add(new Son { Id = 8, IdSousCategories = 2, Raccourci = "wheatley8", Text = "N'appuyez pas", SonCourt = true });
            wheatley.ListeSon.Add(new Son { Id = 9, IdSousCategories = 2, Raccourci = "wheatley9", Text = "Vous êtes maligne", SonCourt = false });
            wheatley.ListeSon.Add(new Son { Id = 10, IdSousCategories = 2, Raccourci = "wheatley10", Text = "l'espace", SonCourt = true });
            wheatley.ListeSon.Add(new Son { Id = 11, IdSousCategories = 2, Raccourci = "wheatley11", Text = "Oh oh", SonCourt = true });
            wheatley.ListeSon.Add(new Son { Id = 12, IdSousCategories = 2, Raccourci = "wheatley12", Text = "Vous êtes des cubes sur pattes", SonCourt = false });
            wheatley.ListeSon.Add(new Son { Id = 13, IdSousCategories = 1, Raccourci = "wheatley13", Text = "Courez vite !!", SonCourt = false });
            wheatley.ListeSon.Add(new Son { Id = 14, IdSousCategories = 1, Raccourci = "wheatley14", Text = "Déçu je suis", SonCourt = true });
            wheatley.ListeSon.Add(new Son { Id = 15, IdSousCategories = 1, Raccourci = "wheatley15", Text = "Le côté obscur", SonCourt = false });
            wheatley.ListeSon.Add(new Son { Id = 16, IdSousCategories = 1, Raccourci = "wheatley16", Text = "On a rien fait de mal", SonCourt = false });
            wheatley.ListeSon.Add(new Son { Id = 17, IdSousCategories = 1, Raccourci = "wheatley17", Text = "Ne touchez à rien", SonCourt = false });
            wheatley.ListeSon.Add(new Son { Id = 18, IdSousCategories = 1, Raccourci = "wheatley18", Text = "Des choix", SonCourt = false });
            wheatley.ListeSon.Add(new Son { Id = 19, IdSousCategories = 1, Raccourci = "wheatley19", Text = "Vous avez une mine superbe", SonCourt = false });
            wheatley.ListeSon.Add(new Son { Id = 20, IdSousCategories = 1, Raccourci = "wheatley20", Text = "Tabarnak", SonCourt = false });
            wheatley.ListeSon.Add(new Son { Id = 21, IdSousCategories = 1, Raccourci = "wheatley21", Text = "Go go go", SonCourt = true });
            wheatley.ListeSon.Add(new Son { Id = 22, IdSousCategories = 1, Raccourci = "wheatley22", Text = "Y a quelqu'un", SonCourt = true });
            wheatley.ListeSon.Add(new Son { Id = 23, IdSousCategories = 1, Raccourci = "wheatley23", Text = "Allo", SonCourt = true });
            wheatley.ListeSon.Add(new Son { Id = 24, IdSousCategories = 1, Raccourci = "wheatley24", Text = "Ce n'est pas une station d'acceuil", SonCourt = false });
            wheatley.ListeSon.Add(new Son { Id = 25, IdSousCategories = 1, Raccourci = "wheatley25", Text = "Je suis là", SonCourt = true });
            wheatley.ListeSon.Add(new Son { Id = 26, IdSousCategories = 1, Raccourci = "wheatley26", Text = "J'appelle même pas ça de la science", SonCourt = false });

            //Tourelle
            var turret = new Perso
            {
                ListeCategorie = new List<Categorie>(),
                ListeSon = new List<Son>(),
                Id = 3,
                Key = "turret",
                Nom = "Tourelle",
                IdLogo = 1,
                Biographie = bioTurret.ToString()
            };
            turret.ListeCategorie.Add(new Categorie { Id = 1, Text = "Fonctionnelle" });
            turret.ListeCategorie.Add(new Categorie { Id = 2, Text = "En panne" });
            turret.ListeSon.Add(new Son { Id = 1, IdSousCategories = 1, Raccourci = "turret1", Text = "Pourquoi?", SonCourt = true });
            turret.ListeSon.Add(new Son { Id = 2, IdSousCategories = 1, Raccourci = "turret2", Text = "Je ne comprend pas", SonCourt = true });
            turret.ListeSon.Add(new Son { Id = 3, IdSousCategories = 1, Raccourci = "turret3", Text = "Cible cerrouillé", SonCourt = true });
            turret.ListeSon.Add(new Son { Id = 4, IdSousCategories = 1, Raccourci = "turret4", Text = "Y a quelqu'un?", SonCourt = true });
            turret.ListeSon.Add(new Son { Id = 5, IdSousCategories = 1, Raccourci = "turret5", Text = "Youpiii!!", SonCourt = true });
            turret.ListeSon.Add(new Son { Id = 6, IdSousCategories = 2, Raccourci = "turret6", Text = "Nooon!!", SonCourt = true });
            turret.ListeSon.Add(new Son { Id = 7, IdSousCategories = 1, Raccourci = "turret7", Text = "A bientot", SonCourt = true });
            turret.ListeSon.Add(new Son { Id = 8, IdSousCategories = 2, Raccourci = "turret8", Text = "A moi la liberté", SonCourt = true });
            turret.ListeSon.Add(new Son { Id = 9, IdSousCategories = 2, Raccourci = "turret9", Text = "Je vole", SonCourt = true });
            turret.ListeSon.Add(new Son { Id = 10, IdSousCategories = 1, Raccourci = "turret10", Text = "Au revoir", SonCourt = true });
            turret.ListeSon.Add(new Son { Id = 11, IdSousCategories = 1, Raccourci = "turret11", Text = "Que faite vous?", SonCourt = true });
            turret.ListeSon.Add(new Son { Id = 12, IdSousCategories = 2, Raccourci = "turret12", Text = "Oh", SonCourt = true });
            turret.ListeSon.Add(new Son { Id = 13, IdSousCategories = 2, Raccourci = "turret13", Text = "Ca brule", SonCourt = true });
            turret.ListeSon.Add(new Son { Id = 14, IdSousCategories = 1, Raccourci = "turret14", Text = "Je vous ai comprise", SonCourt = true });
            turret.ListeSon.Add(new Son { Id = 15, IdSousCategories = 1, Raccourci = "turret15", Text = "Euh vous m'entendez?", SonCourt = true });
            turret.ListeSon.Add(new Son { Id = 16, IdSousCategories = 1, Raccourci = "turret16", Text = "Bravo", SonCourt = true });
            turret.ListeSon.Add(new Son { Id = 17, IdSousCategories = 2, Raccourci = "turret17", Text = "Je ne l'ai jamais aimée", SonCourt = true });
            turret.ListeSon.Add(new Son { Id = 18, IdSousCategories = 2, Raccourci = "turret18", Text = "C'est la faute à pas de chance", SonCourt = false });
            turret.ListeSon.Add(new Son { Id = 19, IdSousCategories = 2, Raccourci = "turret19", Text = "Bigre", SonCourt = true });
            turret.ListeSon.Add(new Son { Id = 20, IdSousCategories = 2, Raccourci = "turret20", Text = "J'ai tout vu c'était un accident", SonCourt = false });
            turret.ListeSon.Add(new Son { Id = 21, IdSousCategories = 1, Raccourci = "turret21", Text = "Feu !", SonCourt = true });
            turret.ListeSon.Add(new Son { Id = 22, IdSousCategories = 2, Raccourci = "turret22", Text = "Désolée", SonCourt = true });
            turret.ListeSon.Add(new Son { Id = 23, IdSousCategories = 2, Raccourci = "turret23", Text = "Erreur critique", SonCourt = true });
            turret.ListeSon.Add(new Son { Id = 24, IdSousCategories = 2, Raccourci = "turret24", Text = "Désolé nous sommes fermés", SonCourt = false });
            turret.ListeSon.Add(new Son { Id = 25, IdSousCategories = 2, Raccourci = "turret25", Text = "Je ne vous en veux pas", SonCourt = false });
            turret.ListeSon.Add(new Son { Id = 26, IdSousCategories = 2, Raccourci = "turret26", Text = "Je ne vous hais pas", SonCourt = false });
            turret.ListeSon.Add(new Son { Id = 27, IdSousCategories = 2, Raccourci = "turret27", Text = "Sans rancune", SonCourt = true });
            turret.ListeSon.Add(new Son { Id = 28, IdSousCategories = 2, Raccourci = "turret28", Text = "Bonne nuit", SonCourt = true });
            turret.ListeSon.Add(new Son { Id = 29, IdSousCategories = 1, Raccourci = "turret29", Text = "Vous êtes toujours là?", SonCourt = true });
            turret.ListeSon.Add(new Son { Id = 30, IdSousCategories = 1, Raccourci = "turret30", Text = "Hé c'est moi", SonCourt = true });
            turret.ListeSon.Add(new Son { Id = 31, IdSousCategories = 2, Raccourci = "turret31", Text = "Erreur inconnue", SonCourt = true });

            //Tourelle défectueuse
            var turretDef = new Perso
            {
                ListeCategorie = new List<Categorie>(),
                ListeSon = new List<Son>(),
                Id = 4,
                Key = "turretDef",
                Nom = "Tourelle défectueuse",
                IdLogo = 1,
                Biographie = bioTurretDef.ToString()
            };
            turretDef.ListeCategorie.Add(new Categorie { Id = 1, Text = "Politesse" });
            turretDef.ListeCategorie.Add(new Categorie { Id = 2, Text = "Tir" });
            turretDef.ListeSon.Add(new Son { Id = 1, IdSousCategories = 1, Raccourci = "turretDef1", Text = "Nous revoila", SonCourt = true });
            turretDef.ListeSon.Add(new Son { Id = 2, IdSousCategories = 1, Raccourci = "turretDef2", Text = "Comme on se retrouve", SonCourt = true });
            turretDef.ListeSon.Add(new Son { Id = 3, IdSousCategories = 1, Raccourci = "turretDef3", Text = "on va gagner", SonCourt = true });
            turretDef.ListeSon.Add(new Son { Id = 4, IdSousCategories = 1, Raccourci = "turretDef4", Text = "Coucou c'est nous", SonCourt = true });
            turretDef.ListeSon.Add(new Son { Id = 5, IdSousCategories = 1, Raccourci = "turretDef5", Text = "Une tourelle s'éveille", SonCourt = false });
            turretDef.ListeSon.Add(new Son { Id = 6, IdSousCategories = 1, Raccourci = "turretDef6", Text = "Une fois ça va", SonCourt = true });
            turretDef.ListeSon.Add(new Son { Id = 7, IdSousCategories = 2, Raccourci = "turretDef7", Text = "Merde", SonCourt = true });
            turretDef.ListeSon.Add(new Son { Id = 8, IdSousCategories = 2, Raccourci = "turretDef8", Text = "Mince", SonCourt = true });
            turretDef.ListeSon.Add(new Son { Id = 9, IdSousCategories = 2, Raccourci = "turretDef9", Text = "Non mais sérieux...", SonCourt = true });
            turretDef.ListeSon.Add(new Son { Id = 10, IdSousCategories = 2, Raccourci = "turretDef10", Text = "Ca fait clic", SonCourt = true });
            turretDef.ListeSon.Add(new Son { Id = 11, IdSousCategories = 2, Raccourci = "turretDef11", Text = "Que c'est génant", SonCourt = true });
            turretDef.ListeSon.Add(new Son { Id = 12, IdSousCategories = 1, Raccourci = "turretDef12", Text = "OK", SonCourt = true });
            turretDef.ListeSon.Add(new Son { Id = 13, IdSousCategories = 3, Raccourci = "turretDef13", Text = "Soyez bonne joueuse", SonCourt = false });
            turretDef.ListeSon.Add(new Son { Id = 14, IdSousCategories = 1, Raccourci = "turretDef14", Text = "Bon courage", SonCourt = true });
            turretDef.ListeSon.Add(new Son { Id = 15, IdSousCategories = 1, Raccourci = "turretDef15", Text = "Sympa la patate", SonCourt = true });
            turretDef.ListeSon.Add(new Son { Id = 16, IdSousCategories = 1, Raccourci = "turretDef16", Text = "Merci pour tout", SonCourt = true });
            turretDef.ListeSon.Add(new Son { Id = 17, IdSousCategories = 1, Raccourci = "turretDef17", Text = "Emmenez moi avec vous", SonCourt = true });
            turretDef.ListeSon.Add(new Son { Id = 18, IdSousCategories = 1, Raccourci = "turretDef18", Text = "Salut ça va", SonCourt = true });
            turretDef.ListeSon.Add(new Son { Id = 19, IdSousCategories = 1, Raccourci = "turretDef19", Text = "Identifiez vous", SonCourt = true });
            turretDef.ListeSon.Add(new Son { Id = 20, IdSousCategories = 2, Raccourci = "turretDef20", Text = "En plein dans le mille", SonCourt = true });
            turretDef.ListeSon.Add(new Son { Id = 21, IdSousCategories = 2, Raccourci = "turretDef21", Text = "Ca va pas le faire", SonCourt = true });
            turretDef.ListeSon.Add(new Son { Id = 22, IdSousCategories = 2, Raccourci = "turretDef22", Text = "Quelqu'un a des munitions", SonCourt = true });
            turretDef.ListeSon.Add(new Son { Id = 23, IdSousCategories = 2, Raccourci = "turretDef23", Text = "Pan pan pan", SonCourt = false });
            turretDef.ListeSon.Add(new Son { Id = 24, IdSousCategories = 2, Raccourci = "turretDef24", Text = "Mouhahaha", SonCourt = true });
            turretDef.ListeSon.Add(new Son { Id = 25, IdSousCategories = 2, Raccourci = "turretDef25", Text = "Je ne suis pas viré", SonCourt = true });
            turretDef.ListeSon.Add(new Son { Id = 26, IdSousCategories = 2, Raccourci = "turretDef26", Text = "Je suis viré je pari?", SonCourt = true });
            turretDef.ListeSon.Add(new Son { Id = 27, IdSousCategories = 2, Raccourci = "turretDef27", Text = "Dans le doute je tire", SonCourt = true });
            turretDef.ListeSon.Add(new Son { Id = 28, IdSousCategories = 2, Raccourci = "turretDef28", Text = "C'est exactement ce que je voulais faire", SonCourt = false });
            turretDef.ListeSon.Add(new Son { Id = 29, IdSousCategories = 1, Raccourci = "turretDef29", Text = "Ca va saigner", SonCourt = true });
            turretDef.ListeSon.Add(new Son { Id = 30, IdSousCategories = 1, Raccourci = "turretDef30", Text = "Dite je dois faire quoi?", SonCourt = false });
            turretDef.ListeSon.Add(new Son { Id = 31, IdSousCategories = 2, Raccourci = "turretDef31", Text = "Ah crotte", SonCourt = true });
            turretDef.ListeSon.Add(new Son { Id = 32, IdSousCategories = 2, Raccourci = "turretDef32", Text = "C'est normal qu'on voie rien", SonCourt = false });
            turretDef.ListeSon.Add(new Son { Id = 33, IdSousCategories = 1, Raccourci = "turretDef33", Text = "J'ai fait ratatata", SonCourt = false });



            //Processeur de l'aventure
            var procAventure = new Perso
            {
                ListeCategorie = new List<Categorie>(),
                ListeSon = new List<Son>(),
                Id = 5,
                Key = "procAventure",
                Nom = "Processeur de l'aventure",
                IdLogo = 2,
                Biographie = bioAventure.ToString()
            };
            procAventure.ListeCategorie.Add(new Categorie { Id = 1, Text = "Divers" });
            procAventure.ListeSon.Add(new Son { Id = 1, IdSousCategories = 1, Raccourci = "procAventure1", Text = "Présentation", SonCourt = false });
            procAventure.ListeSon.Add(new Son { Id = 2, IdSousCategories = 1, Raccourci = "procAventure2", Text = "Tiens un comtpe à rebours", SonCourt = false });
            procAventure.ListeSon.Add(new Son { Id = 3, IdSousCategories = 1, Raccourci = "procAventure3", Text = "Une femme d'action hein !", SonCourt = false });
            procAventure.ListeSon.Add(new Son { Id = 4, IdSousCategories = 1, Raccourci = "procAventure4", Text = "L'espace", SonCourt = false });
            procAventure.ListeSon.Add(new Son { Id = 5, IdSousCategories = 1, Raccourci = "procAventure5", Text = "En route pour l'aventure", SonCourt = false });
            procAventure.ListeSon.Add(new Son { Id = 6, IdSousCategories = 1, Raccourci = "procAventure6", Text = "Zéro incidence", SonCourt = false });
            procAventure.ListeSon.Add(new Son { Id = 7, IdSousCategories = 1, Raccourci = "procAventure7", Text = "Oh la ferme", SonCourt = true });
            procAventure.ListeSon.Add(new Son { Id = 8, IdSousCategories = 1, Raccourci = "procAventure8", Text = "Mattraquez le !", SonCourt = false });
            procAventure.ListeSon.Add(new Son { Id = 9, IdSousCategories = 1, Raccourci = "procAventure9", Text = "T'aime ça hein !", SonCourt = true });
            procAventure.ListeSon.Add(new Son { Id = 10, IdSousCategories = 1, Raccourci = "procAventure10", Text = "Un bon coup de poing", SonCourt = false });
            procAventure.ListeSon.Add(new Son { Id = 11, IdSousCategories = 1, Raccourci = "procAventure11", Text = "Rouer de coup", SonCourt = false });
            procAventure.ListeSon.Add(new Son { Id = 12, IdSousCategories = 1, Raccourci = "procAventure12", Text = "Diversion", SonCourt = false });


            //Processeur de curiosité
            var procCuriosite = new Perso
            {
                ListeCategorie = new List<Categorie>(),
                ListeSon = new List<Son>(),
                Id = 6,
                Key = "procCuriosite",
                Nom = "Processeur de la curiosité",
                IdLogo = 2,
                Biographie = ""
            };
            procCuriosite.ListeCategorie.Add(new Categorie { Id = 1, Text = "Divers" });
            procCuriosite.ListeSon.Add(new Son { Id = 1, IdSousCategories = 1, Raccourci = "procCuriosite1", Text = "Oh! C'est quoi", SonCourt = true });
            procCuriosite.ListeSon.Add(new Son { Id = 2, IdSousCategories = 1, Raccourci = "procCuriosite2", Text = "Ouh, il y a des chiffres inscrit", SonCourt = true });
            procCuriosite.ListeSon.Add(new Son { Id = 3, IdSousCategories = 1, Raccourci = "procCuriosite3", Text = "Qu'est ce que c'est?", SonCourt = true });
            procCuriosite.ListeSon.Add(new Son { Id = 4, IdSousCategories = 1, Raccourci = "procCuriosite4", Text = "Voyons voir", SonCourt = true });
            procCuriosite.ListeSon.Add(new Son { Id = 5, IdSousCategories = 1, Raccourci = "procCuriosite5", Text = "Quel est ce bruit", SonCourt = true });
            procCuriosite.ListeSon.Add(new Son { Id = 6, IdSousCategories = 1, Raccourci = "procCuriosite6", Text = "C'est quoi", SonCourt = true });
            procCuriosite.ListeSon.Add(new Son { Id = 7, IdSousCategories = 1, Raccourci = "procCuriosite7", Text = "Hé regardez un peu ça", SonCourt = true });
            procCuriosite.ListeSon.Add(new Son { Id = 8, IdSousCategories = 1, Raccourci = "procCuriosite8", Text = "Où allons nous?", SonCourt = true });


            //Processeur de recette
            var procRecette = new Perso
            {
                ListeCategorie = new List<Categorie>(),
                ListeSon = new List<Son>(),
                Id = 7,
                Key = "procRecette",
                Nom = "Processeur de la recette",
                IdLogo = 2,
                Biographie = ""
            };
            procRecette.ListeCategorie.Add(new Categorie { Id = 1, Text = "Divers" });
            procRecette.ListeSon.Add(new Son { Id = 1, IdSousCategories = 1, Raccourci = "procRecette1", Text = "Préparation d'un gateau", SonCourt = true });
            procRecette.ListeSon.Add(new Son { Id = 2, IdSousCategories = 1, Raccourci = "procRecette2", Text = "agents conservateurs", SonCourt = false });
            procRecette.ListeSon.Add(new Son { Id = 3, IdSousCategories = 1, Raccourci = "procRecette3", Text = "Repose tete", SonCourt = true });
            procRecette.ListeSon.Add(new Son { Id = 4, IdSousCategories = 1, Raccourci = "procRecette4", Text = "Dés de rhubarbe", SonCourt = true });
            procRecette.ListeSon.Add(new Son { Id = 5, IdSousCategories = 1, Raccourci = "procRecette5", Text = "Composants organiques", SonCourt = false });
            procRecette.ListeSon.Add(new Son { Id = 6, IdSousCategories = 1, Raccourci = "procRecette6", Text = "Déchets", SonCourt = true });
            procRecette.ListeSon.Add(new Son { Id = 7, IdSousCategories = 1, Raccourci = "procRecette7", Text = "Poisson", SonCourt = true });
            procRecette.ListeSon.Add(new Son { Id = 8, IdSousCategories = 1, Raccourci = "procRecette8", Text = "Résine", SonCourt = true });
            procRecette.ListeSon.Add(new Son { Id = 9, IdSousCategories = 1, Raccourci = "procRecette9", Text = "Membrane", SonCourt = true });
            procRecette.ListeSon.Add(new Son { Id = 10, IdSousCategories = 1, Raccourci = "procRecette10", Text = "Rhubarbe", SonCourt = true });
            procRecette.ListeSon.Add(new Son { Id = 11, IdSousCategories = 1, Raccourci = "procRecette11", Text = "Injecteur", SonCourt = true });


            //Processeur du savoir
            var procSavoir = new Perso
            {
                ListeCategorie = new List<Categorie>(),
                ListeSon = new List<Son>(),
                Id = 8,
                Key = "procSavoir",
                Nom = "Processeur du savoir",
                IdLogo = 2,
                Biographie = bioInfo.ToString()
            };
            procSavoir.ListeCategorie.Add(new Categorie { Id = 1, Text = "Divers" });
            procSavoir.ListeSon.Add(new Son { Id = 1, IdSousCategories = 1, Raccourci = "procSavoir1", Text = "Mort violente", SonCourt = false });
            procSavoir.ListeSon.Add(new Son { Id = 2, IdSousCategories = 1, Raccourci = "procSavoir2", Text = "Infos exactes", SonCourt = false });
            procSavoir.ListeSon.Add(new Son { Id = 3, IdSousCategories = 1, Raccourci = "procSavoir3", Text = "Poséidon", SonCourt = false });
            procSavoir.ListeSon.Add(new Son { Id = 4, IdSousCategories = 1, Raccourci = "procSavoir4", Text = "Tour de magie", SonCourt = false });
            procSavoir.ListeSon.Add(new Son { Id = 5, IdSousCategories = 1, Raccourci = "procSavoir5", Text = "Photocopieuse", SonCourt = false });
            procSavoir.ListeSon.Add(new Son { Id = 6, IdSousCategories = 1, Raccourci = "procSavoir6", Text = "Halley", SonCourt = false });
            procSavoir.ListeSon.Add(new Son { Id = 7, IdSousCategories = 1, Raccourci = "procSavoir7", Text = "Carbone", SonCourt = false });
            procSavoir.ListeSon.Add(new Son { Id = 8, IdSousCategories = 1, Raccourci = "procSavoir8", Text = "Marie Curie", SonCourt = false });
            procSavoir.ListeSon.Add(new Son { Id = 9, IdSousCategories = 1, Raccourci = "procSavoir9", Text = "Le gallion", SonCourt = false });
            procSavoir.ListeSon.Add(new Son { Id = 10, IdSousCategories = 1, Raccourci = "procSavoir10", Text = "Pi", SonCourt = false });
            procSavoir.ListeSon.Add(new Son { Id = 11, IdSousCategories = 1, Raccourci = "procSavoir11", Text = "Les avocats", SonCourt = false });
            procSavoir.ListeSon.Add(new Son { Id = 12, IdSousCategories = 1, Raccourci = "procSavoir12", Text = "Le soleil", SonCourt = false });
            procSavoir.ListeSon.Add(new Son { Id = 13, IdSousCategories = 1, Raccourci = "procSavoir13", Text = "Humain sous l'eau", SonCourt = false });
            procSavoir.ListeSon.Add(new Son { Id = 14, IdSousCategories = 1, Raccourci = "procSavoir14", Text = "Rat", SonCourt = false });
            procSavoir.ListeSon.Add(new Son { Id = 15, IdSousCategories = 1, Raccourci = "procSavoir15", Text = "Ver solitaire", SonCourt = false });
            procSavoir.ListeSon.Add(new Son { Id = 16, IdSousCategories = 1, Raccourci = "procSavoir16", Text = "Mauvaise haleine", SonCourt = false });
            procSavoir.ListeSon.Add(new Son { Id = 16, IdSousCategories = 1, Raccourci = "procSavoir17", Text = "Dentifrice", SonCourt = false });


            //Processeur de l'espace
            var procSpace = new Perso
            {
                ListeCategorie = new List<Categorie>(),
                ListeSon = new List<Son>(),
                Id = 9,
                Key = "procSpace",
                Nom = "Processeur de l'espace",
                IdLogo = 2,
                Biographie = bioEspace.ToString()
            };
            procSpace.ListeCategorie.Add(new Categorie { Id = 1, Text = "Divers" });
            procSpace.ListeSon.Add(new Son { Id = 1, IdSousCategories = 1, Raccourci = "procSpace1", Text = "Votre trucs préféré", SonCourt = false });
            procSpace.ListeSon.Add(new Son { Id = 2, IdSousCategories = 1, Raccourci = "procSpace2", Text = "L'espace", SonCourt = true });
            procSpace.ListeSon.Add(new Son { Id = 3, IdSousCategories = 1, Raccourci = "procSpace3", Text = "Faut aller dans l'espace", SonCourt = false });
            procSpace.ListeSon.Add(new Son { Id = 4, IdSousCategories = 1, Raccourci = "procSpace4", Text = "Espace sarasin", SonCourt = false });
            procSpace.ListeSon.Add(new Son { Id = 5, IdSousCategories = 1, Raccourci = "procSpace5", Text = "Police de l'espace", SonCourt = false });
            procSpace.ListeSon.Add(new Son { Id = 6, IdSousCategories = 1, Raccourci = "procSpace6", Text = "spatiopoulet", SonCourt = false });
            procSpace.ListeSon.Add(new Son { Id = 7, IdSousCategories = 1, Raccourci = "procSpace7", Text = "Partons dans l'espace", SonCourt = false });
            procSpace.ListeSon.Add(new Son { Id = 8, IdSousCategories = 1, Raccourci = "procSpace8", Text = "Une éclipse", SonCourt = false });
            procSpace.ListeSon.Add(new Son { Id = 9, IdSousCategories = 1, Raccourci = "procSpace9", Text = "Vive l'espace", SonCourt = false });
            procSpace.ListeSon.Add(new Son { Id = 10, IdSousCategories = 1, Raccourci = "procSpace10", Text = "Tu as été choisi", SonCourt = false });
            procSpace.ListeSon.Add(new Son { Id = 11, IdSousCategories = 1, Raccourci = "procSpace11", Text = "Une étoile", SonCourt = false });
            procSpace.ListeSon.Add(new Son { Id = 12, IdSousCategories = 1, Raccourci = "procSpace12", Text = "J'aime pas l'espace", SonCourt = false });
            procSpace.ListeSon.Add(new Son { Id = 13, IdSousCategories = 1, Raccourci = "procSpace13", Text = "Je veux aller sur terre", SonCourt = true });
            procSpace.ListeSon.Add(new Son { Id = 14, IdSousCategories = 1, Raccourci = "procSpace14", Text = "Tribunal spatial", SonCourt = false });
            procSpace.ListeSon.Add(new Son { Id = 15, IdSousCategories = 1, Raccourci = "procSpace15", Text = "Eh m'dame", SonCourt = true });


            //Annonceur
            var annonceur = new Perso
            {
                ListeCategorie = new List<Categorie>(),
                ListeSon = new List<Son>(),
                Id = 10,
                Key = "annonceur",
                Nom = "Annonceur",
                IdLogo = 2,
                Biographie = bioAnnonceur.ToString()
            };

            annonceur.ListeCategorie.Add(new Categorie { Id = 1, Text = "Salle de test"});
            annonceur.ListeCategorie.Add(new Categorie { Id = 2, Text = "Coop" });
            annonceur.ListeCategorie.Add(new Categorie { Id = 3, Text = "Manufacture des tourelles" });
            annonceur.ListeSon.Add(new Son { Id = 1, IdSousCategories = 1, Raccourci = "annonceur1", Text = "Difficultés techniques", SonCourt = false });
            annonceur.ListeSon.Add(new Son { Id = 2, IdSousCategories = 1, Raccourci = "annonceur2", Text = "Découverte du centre", SonCourt = false });
            annonceur.ListeSon.Add(new Son { Id = 3, IdSousCategories = 1, Raccourci = "annonceur3", Text = "Découverte être l'avenir", SonCourt = false });
            annonceur.ListeSon.Add(new Son { Id = 4, IdSousCategories = 1, Raccourci = "annonceur4", Text = "Vous n'êtes pas seul", SonCourt = false });
            annonceur.ListeSon.Add(new Son { Id = 5, IdSousCategories = 1, Raccourci = "annonceur5", Text = "Androide militaire mortel", SonCourt = false });
            annonceur.ListeSon.Add(new Son { Id = 6, IdSousCategories = 1, Raccourci = "annonceur6", Text = "Androide militaire mortel 2", SonCourt = false });
            annonceur.ListeSon.Add(new Son { Id = 7, IdSousCategories = 1, Raccourci = "annonceur7", Text = "Diagnostic de sarcasme", SonCourt = true });
            annonceur.ListeSon.Add(new Son { Id = 8, IdSousCategories = 2, Raccourci = "annonceur8", Text = "Accréditation", SonCourt = false });
            annonceur.ListeSon.Add(new Son { Id = 9, IdSousCategories = 3, Raccourci = "annonceur9", Text = "Ne pas solliciter les tourelles", SonCourt = false });
            annonceur.ListeSon.Add(new Son { Id = 10, IdSousCategories = 3, Raccourci = "annonceur10", Text = "Niveau de toxine", SonCourt = false });

            var bonus = new Perso
            {
                ListeCategorie = new List<Categorie>(),
                ListeSon = new List<Son>(),
                Id = 11,
                Key = "bonus",
                Nom = "Bonus",
                IdLogo = 2,
                Biographie = ""
            };
            bonus.ListeCategorie.Add(new Categorie { Id = 1, Text = "Sonneries" });
            bonus.ListeCategorie.Add(new Categorie { Id = 2, Text = "Musique" });
            bonus.ListeSon.Add(new Son { Id = 1, IdSousCategories = 1, Raccourci = "bonus1", Text = "Science is fun", SonCourt = true });
            bonus.ListeSon.Add(new Son { Id = 2, IdSousCategories = 1, Raccourci = "bonus2", Text = "The courtesy call", SonCourt = true });
            bonus.ListeSon.Add(new Son { Id = 3, IdSousCategories = 1, Raccourci = "bonus3", Text = "The friendly faith", SonCourt = true });
            bonus.ListeSon.Add(new Son { Id = 4, IdSousCategories = 1, Raccourci = "bonus4", Text = "I saw a deer today", SonCourt = true });
            bonus.ListeSon.Add(new Son { Id = 5, IdSousCategories = 1, Raccourci = "bonus5", Text = "Turret serenade", SonCourt = true });
            bonus.ListeSon.Add(new Son { Id = 6, IdSousCategories = 1, Raccourci = "bonus6", Text = "Tragedy plus time", SonCourt = true });
            bonus.ListeSon.Add(new Son { Id = 7, IdSousCategories = 1, Raccourci = "bonus7", Text = "Bouton negatif", SonCourt = true });
            bonus.ListeSon.Add(new Son { Id = 8, IdSousCategories = 1, Raccourci = "bonus8", Text = "Bouton positif", SonCourt = true });
            bonus.ListeSon.Add(new Son { Id = 9, IdSousCategories = 1, Raccourci = "bonus9", Text = "Fermeture porte", SonCourt = true });
            bonus.ListeSon.Add(new Son { Id = 10, IdSousCategories = 1, Raccourci = "bonus10", Text = "Ouverture porte", SonCourt = true });
            bonus.ListeSon.Add(new Son { Id = 11, IdSousCategories = 1, Raccourci = "bonus11", Text = "Peinture bleue", SonCourt = true });
            bonus.ListeSon.Add(new Son { Id = 12, IdSousCategories = 1, Raccourci = "bonus12", Text = "Portail bleu", SonCourt = true });
            bonus.ListeSon.Add(new Son { Id = 13, IdSousCategories = 1, Raccourci = "bonus13", Text = "Portail orange", SonCourt = true });
            bonus.ListeSon.Add(new Son { Id = 14, IdSousCategories = 1, Raccourci = "bonus14", Text = "Tourelle", SonCourt = true });
            bonus.ListeSon.Add(new Son { Id = 15, IdSousCategories = 1, Raccourci = "bonus15", Text = "More science", SonCourt = true });
            bonus.ListeSon.Add(new Son { Id = 16, IdSousCategories = 1, Raccourci = "bonus16", Text = "You will be perfect", SonCourt = true });
            bonus.ListeSon.Add(new Son { Id = 17, IdSousCategories = 1, Raccourci = "bonus17", Text = "Hall of science", SonCourt = true });
            bonus.ListeSon.Add(new Son { Id = 18, IdSousCategories = 1, Raccourci = "bonus18", Text = "Your precious moon", SonCourt = true });
            bonus.ListeSon.Add(new Son { Id = 19, IdSousCategories = 1, Raccourci = "bonus19", Text = "Cara mia adio", SonCourt = true });
            bonus.ListeSon.Add(new Son { Id = 20, IdSousCategories = 1, Raccourci = "bonus20", Text = "Musique of the spheres", SonCourt = true });
            bonus.ListeSon.Add(new Son { Id = 21, IdSousCategories = 1, Raccourci = "bonus21", Text = "Want you gone", SonCourt = true });
            bonus.ListeSon.Add(new Son { Id = 22, IdSousCategories = 1, Raccourci = "bonus22", Text = "Part of the control group", SonCourt = true });
            bonus.ListeSon.Add(new Son { Id = 23, IdSousCategories = 1, Raccourci = "bonus23", Text = "PotatOS", SonCourt = true });
            bonus.ListeSon.Add(new Son { Id = 24, IdSousCategories = 1, Raccourci = "bonus24", Text = "Some assembly required", SonCourt = true });
            bonus.ListeSon.Add(new Son { Id = 25, IdSousCategories = 1, Raccourci = "bonus25", Text = "Robots", SonCourt = true });
            bonus.ListeSon.Add(new Son { Id = 26, IdSousCategories = 2, Raccourci = "bonus26", Text = "Cara mia adio - Musique", SonCourt = false });
            bonus.ListeSon.Add(new Son { Id = 27, IdSousCategories = 2, Raccourci = "bonus27", Text = "Want you gone - Musique", SonCourt = false });
            bonus.ListeSon.Add(new Son { Id = 28, IdSousCategories = 2, Raccourci = "bonus28", Text = "Science is fun - Musique", SonCourt = false });
            bonus.ListeSon.Add(new Son { Id = 29, IdSousCategories = 2, Raccourci = "bonus29", Text = "Music of the sphere - Musique", SonCourt = false });


            //ajout des données à la liste finale
            var liste = new List<Perso>
            {
                cave,
                glados,
                wheatley,
                turret,
                turretDef,
                procAventure,
                procCuriosite,
                procRecette,
                procSavoir,
                procSpace,
                annonceur,
                bonus
            };

            //serialization de la liste
            var wr = new StringWriter();
            var xs = new XmlSerializer(typeof(List<Perso>));
            xs.Serialize(wr, liste);

            //écriture dans le fichier
            File.WriteAllText("data.xml", wr.ToString());

            //affichage des données
            Console.WriteLine(wr.ToString());
            Console.WriteLine("Opération Terminé");
            Console.WriteLine("Appuyez sur une touche pour continuer");
            Console.ReadKey();

        }
    }
}
