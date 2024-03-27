using System.Text.Json;
bool DebugModeOFF = true; //debug mode on = false
bool PromptON = true;
bool LetreparletreOFF = false;
await UltraLauncher();

async Task UltraLauncher()
{
    if (DebugModeOFF)
    {
        Prompt();
        string choixFonction = ChoisirUneAction();
        switch (choixFonction)
        {
            case "1":
                Console.Title = "Histoire";
                Histoire();
                break;
            default: break;
        }
        switch (choixFonction)
        {
            case "":
                Console.Clear();
                UltraLauncher();
                break;
            default: break;
        }


        switch (choixFonction)
        {
            case "2":
                Console.Title = "Calculatrice";
                Calculatrice();

                break;
            default: break;
        }

        switch (choixFonction)
        {
            case "3":
                Console.Title = "Timer";
                Console.Clear();
                Timer(DebugModeOFF);

                break;
            default: break;
        }

        switch (choixFonction)
        {
            case "4":
                int Crono = 0;
                bool running = false;

                LettreParLettre("Appuyez sur la touche Espace pour démarrer le chronomètre...");

                ConsoleKeyInfo touche = Console.ReadKey(); // Lire la prochaine touche pressée par l'utilisateur
                if (touche.Key == ConsoleKey.Spacebar)
                {
                    running = true;
                }

                while (true)
                {
                    if (running)
                    {
                        Crono++;
                        Thread.Sleep(1000);
                        Console.WriteLine(Crono); // Afficher le compteur

                        if (Console.KeyAvailable)
                        {
                            ConsoleKeyInfo StopCrono = Console.ReadKey(true); // Lire la prochaine touche pressée par l'utilisateur
                            if (StopCrono.Key == ConsoleKey.Spacebar)
                            {
                                LettreParLettre($"Le chronomètre a mesuré {Crono} secondes");
                                LettreParLettre("");
                                LettreParLettre("Appuyez sur une touche pour revenir au menu principal...");
                                Console.ReadKey();
                                Console.Clear();
                                UltraLauncher();
                                break; // Sortir de la boucle une fois que le chronomètre est arrêté
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Le chronomètre est en attente de démarrage...");
                        Thread.Sleep(1000); // Attente de 1 seconde avant de vérifier à nouveau
                    }
                }

                break;
            default: break;
        }
        switch (choixFonction)
        {
            case "5":
                Console.Clear();
                Snake.Play();


                break;
            default: break;
        }


        if (choixFonction == "6")
        {
            Console.Clear();
            await AppelApi();
        }
        FinDuProgramme();
    }
    else
    {
        PromptON = false;
        DebugModeOFF = true;

        UltraLauncher();


    }
}


void LettreParLettre(string phrase)
{   
        Random aleatoire = new Random();

        if (DebugModeOFF)
        {
            foreach (char c in phrase)
            {

                int attente = aleatoire.Next(100); //Génère un entier compris entre 0 et 1000        
                Console.Write(c);
                // attendre un temps
                Thread.Sleep(attente);

            }
            Console.WriteLine();

        }


    
   
    }
    // v2 attendre un temps aléatoire entre 0.1s et 1 s


int LireUnNombre()
{

    Console.WriteLine("Ecrire chiffre");
    string nombreLu = Console.ReadLine();

    int nb1;

    while (!Int32.TryParse(nombreLu, out nb1))

    {
        LettreParLettre($"{nombreLu} n'est pas un nombre entier");
        Console.WriteLine("Ecrire un chiffre");
        nombreLu = Console.ReadLine();
    }

    return nb1;
}

void Timer(bool demo)
{
    Console.Title = "Timer";
    Console.WriteLine("Choisissez le temps de votre timer, en seconde");
    string TimerTempChoisoire = Console.ReadLine();
    Console.Clear(); int timer1;
    while (!Int32.TryParse(TimerTempChoisoire, out timer1))
    { }

    Thread.Sleep(timer1 * 1_000);

    Console.Beep();
    LettreParLettre("temp ecoulé ");

    Console.Beep(659, 125); Console.Beep(659, 125); Thread.Sleep(125); Console.Beep(659, 125);
    Thread.Sleep(167); Console.Beep(523, 125); Console.Beep(659, 125); Thread.Sleep(125); Console.Beep(784, 125);
    Thread.Sleep(375); Console.Beep(392, 125); Thread.Sleep(375); Console.Beep(523, 125); Thread.Sleep(250);
    Console.Beep(392, 125); Thread.Sleep(250); Console.Beep(330, 125); Thread.Sleep(250); Console.Beep(440, 125);
    Thread.Sleep(125); Console.Beep(494, 125); Thread.Sleep(125); Console.Beep(466, 125); Thread.Sleep(42);
    Console.Beep(440, 125); Thread.Sleep(125); Console.Beep(392, 125); Thread.Sleep(125); Console.Beep(659, 125);
    Thread.Sleep(125); Console.Beep(784, 125); Thread.Sleep(125); Console.Beep(880, 125); Thread.Sleep(125);
    Console.Beep(698, 125); Console.Beep(784, 125); Thread.Sleep(125); Console.Beep(659, 125); Thread.Sleep(125);
    Console.Beep(523, 125); Thread.Sleep(125); Console.Beep(587, 125); Console.Beep(494, 125); Thread.Sleep(125);
    Console.Beep(523, 125); Thread.Sleep(250); Console.Beep(392, 125); Thread.Sleep(250); Console.Beep(330, 125);
    Thread.Sleep(250); Console.Beep(440, 125); Thread.Sleep(125); Console.Beep(494, 125); Thread.Sleep(125);
    Console.Beep(466, 125); Thread.Sleep(42); Console.Beep(440, 125); Thread.Sleep(125); Console.Beep(392, 125);
    Thread.Sleep(125); Console.Beep(659, 125); Thread.Sleep(125); Console.Beep(784, 125); Thread.Sleep(125);
    Console.Beep(880, 125); Thread.Sleep(125); Console.Beep(698, 125); Console.Beep(784, 125); Thread.Sleep(125);
    Console.Beep(659, 125); Thread.Sleep(125); Console.Beep(523, 125); Thread.Sleep(125); Console.Beep(587, 125);
    Console.Beep(494, 125); Thread.Sleep(375); Console.Beep(784, 125); Console.Beep(740, 125); Console.Beep(698, 125);
    Thread.Sleep(42); Console.Beep(622, 125); Thread.Sleep(125); Console.Beep(659, 125); Thread.Sleep(167);
    Console.Beep(415, 125); Console.Beep(440, 125); Console.Beep(523, 125); Thread.Sleep(125); Console.Beep(440, 125);
    Console.Beep(523, 125); Console.Beep(587, 125); Thread.Sleep(250); Console.Beep(784, 125); Console.Beep(740, 125);
    Console.Beep(698, 125); Thread.Sleep(42); Console.Beep(622, 125); Thread.Sleep(125); Console.Beep(659, 125);
    Thread.Sleep(167); Console.Beep(698, 125); Thread.Sleep(125); Console.Beep(698, 125); Console.Beep(698, 125);
    Thread.Sleep(625); Console.Beep(784, 125); Console.Beep(740, 125); Console.Beep(698, 125); Thread.Sleep(42);
    Console.Beep(622, 125); Thread.Sleep(125); Console.Beep(659, 125); Thread.Sleep(167); Console.Beep(415, 125);
    Console.Beep(440, 125); Console.Beep(523, 125); Thread.Sleep(125); Console.Beep(440, 125); Console.Beep(523, 125);
    Console.Beep(587, 125); Thread.Sleep(250); Console.Beep(622, 125); Thread.Sleep(250); Console.Beep(587, 125);
    Thread.Sleep(250); Console.Beep(523, 125); Thread.Sleep(1125); Console.Beep(784, 125); Console.Beep(740, 125);
    Console.Beep(698, 125); Thread.Sleep(42); Console.Beep(622, 125); Thread.Sleep(125); Console.Beep(659, 125);
    Thread.Sleep(167); Console.Beep(415, 125); Console.Beep(440, 125); Console.Beep(523, 125); Thread.Sleep(125);
    Console.Beep(440, 125); Console.Beep(523, 125); Console.Beep(587, 125); Thread.Sleep(250); Console.Beep(784, 125);
    Console.Beep(740, 125); Console.Beep(698, 125); Thread.Sleep(42); Console.Beep(622, 125); Thread.Sleep(125);
    Console.Beep(659, 125); Thread.Sleep(167); Console.Beep(698, 125); Thread.Sleep(125); Console.Beep(698, 125);
    Console.Beep(698, 125); Thread.Sleep(625); Console.Beep(784, 125); Console.Beep(740, 125); Console.Beep(698, 125);
    Thread.Sleep(42); Console.Beep(622, 125); Thread.Sleep(125); Console.Beep(659, 125); Thread.Sleep(167);
    Console.Beep(415, 125); Console.Beep(440, 125); Console.Beep(523, 125); Thread.Sleep(125); Console.Beep(440, 125);
    Console.Beep(523, 125); Console.Beep(587, 125); Thread.Sleep(250); Console.Beep(622, 125); Thread.Sleep(250);
    Console.Beep(587, 125);
    Thread.Sleep(250); Console.Beep(523, 125);

}

void Prompt()
{
    if (PromptON)
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.Title = "Ultra-launcher";

        X(@"
 /$$   /$$ /$$    /$$$$$$$$ /$$$$$$$   /$$$$$$                                         
| $$  | $$| $$   |__  $$__/| $$__  $$ /$$__  $$                                        
| $$  | $$| $$      | $$   | $$  \ $$| $$  \ $$                                        
| $$  | $$| $$      | $$   | $$$$$$$/| $$$$$$$$                                        
| $$  | $$| $$      | $$   | $$__  $$| $$__  $$                                        
| $$  | $$| $$      | $$   | $$  \ $$| $$  | $$                                        
|  $$$$$$/| $$$$$$$$| $$   | $$  | $$| $$  | $$                                        
 \______/ |________/|__/   |__/  |__/|__/  |__/                                        
                                                                                       
                                                                                       
                                                                                       
 /$$        /$$$$$$  /$$   /$$ /$$   /$$  /$$$$$$  /$$   /$$ /$$$$$$$$ /$$$$$$$        
| $$       /$$__  $$| $$  | $$| $$$ | $$ /$$__  $$| $$  | $$| $$_____/| $$__  $$       
| $$      | $$  \ $$| $$  | $$| $$$$| $$| $$  \__/| $$  | $$| $$      | $$  \ $$       
| $$      | $$$$$$$$| $$  | $$| $$ $$ $$| $$      | $$$$$$$$| $$$$$   | $$$$$$$/       
| $$      | $$__  $$| $$  | $$| $$  $$$$| $$      | $$__  $$| $$__/   | $$__  $$       
| $$      | $$  | $$| $$  | $$| $$\  $$$| $$    $$| $$  | $$| $$      | $$  \ $$       
| $$$$$$$$| $$  | $$|  $$$$$$/| $$ \  $$|  $$$$$$/| $$  | $$| $$$$$$$$| $$  | $$       
|________/|__/  |__/ \______/ |__/  \__/ \______/ |__/  |__/|________/|__/  |__//$$$$$$
                                                                               |______/                                                                                   
");
        Thread.Sleep(10);
        Console.Clear();
    }
    else
    {
        Console.Clear();

    }
}



async Task AppelApi()
{
    using HttpClient client = new();
    var histoires = await ObtenirLesHistoiresAsync(client);
    foreach (var histoire in histoires)
    {
        Console.WriteLine($"Liste des histoires:");
        Console.WriteLine($" Choix {histoire.id} Titre : {histoire.titre}");
    }
    Console.WriteLine();
    Console.Write(">");
    int choix = LireUnNombre();
    var histoireChoisie = histoires.FirstOrDefault(h => h.id == choix);
    Console.WriteLine($"vous avez choisi {histoireChoisie.titre} ");
    Console.WriteLine(histoireChoisie.contenu);
}

static async Task<IReadOnlyList<HistoireEnLigne>> ObtenirLesHistoiresAsync(HttpClient client)
{
    await using Stream stream =
        await client.GetStreamAsync("https://localhost:7179/Histoires");
    var histoires = await JsonSerializer.DeserializeAsync<List<HistoireEnLigne>>(stream);
    return histoires;
}

void Calculatrice()
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.DarkBlue;
    X(@"
    _____         _      _____ _    _ _            _______ _____  _____ _____ ______ 
  / ____|   /\   | |    / ____| |  | | |        /\|__   __|  __ \|_   _/ ____|  ____|
 | |       /  \  | |   | |    | |  | | |       /  \  | |  | |__) | | || |    | |__   
 | |      / /\ \ | |   | |    | |  | | |      / /\ \ | |  |  _  /  | || |    |  __|  
 | |____ / ____ \| |___| |____| |__| | |____ / ____ \| |  | | \ \ _| || |____| |____ 
  \_____/_/    \_\______\_____|\____/|______/_/    \_\_|  |_|  \_\_____\_____|______| (beta)
                                                                                     
                                                                                      
            ");





    X("Bienvenue dans la calculatrice!");

    while (true)
    {
        LettreParLettre("Veuillez entrer le premier nombre:");
        double nombre1 = Convert.ToDouble(Console.ReadLine());
        LettreParLettre("Veuillez choisir Un calculateur : (+, -, *, /)");
        char operation = Convert.ToChar(Console.ReadLine());

        LettreParLettre("Veuillez entrer le deuxième nombre:");
        double nombre2 = Convert.ToDouble(Console.ReadLine());



        double resultat = 0;

        switch (operation)
        {
            case '+':
                resultat = nombre1 + nombre2;
                break;
            case '-':
                resultat = nombre1 - nombre2;
                break;
            case '*':
                resultat = nombre1 * nombre2;
                break;
            case '/':
                resultat = nombre1 / nombre2;
                break;
            default:
                Console.WriteLine("Opération invalide!");
                break;
        }

        Console.WriteLine("Le résultat est: " + resultat);

        Console.WriteLine("Voulez-vous continuer? (Oui/Non)");
        string continuer = Console.ReadLine();

        if (continuer.ToLower() != "oui")
            break;
    }

    Console.WriteLine("Merci d'avoir utilisé la calculatrice!");



    // ancien code 
    //  int nb1 = LireUnNombre();
    // int nb2 = LireUnNombre();
    //int total = nb1 + nb2;
    //LettreParLettre($"{nb1} + {nb2} = {total}");
}

void Histoire()
{
    string nomHero = SaisirNomHero();
    string choix = ChoisirUneHistoire(nomHero);

    while (DoitContinuer(choix))
    {
        RaconterUneHistoire(nomHero, choix);
        choix = ChoisirUneHistoire(nomHero);
    }
}

string SaisirNomHero()
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("ecrit ton Nom ");
    Console.WriteLine(">");
    return Console.ReadLine();
}

string ChoisirUneHistoire(string nomHero)
{
    Console.ForegroundColor= ConsoleColor.Black;
    Console.BackgroundColor = ConsoleColor.Yellow;
    Console.Clear();
    X(@"

  _    _ _____  _____ _______ ____ _____ _____  ______ 
 | |  | |_   _|/ ____|__   __/ __ \_   _|  __ \|  ____|
 | |__| | | | | (___    | | | |  | || | | |__) | |__   
 |  __  | | |  \___ \   | | | |  | || | |  _  /|  __|  
 | |  | |_| |_ ____) |  | | | |__| || |_| | \ \| |____ 
 |_|  |_|_____|_____/   |_|  \____/_____|_|  \_\______| ");
    Console.WriteLine("Choisi une histoire " + nomHero);
    Console.WriteLine("0 => Quitter");
    Console.WriteLine("1 => Histoire: le gateau");
    Console.WriteLine("2 => Le chien abandonné");
    Console.WriteLine("3 => Le Hero");
    Console.WriteLine("4 => Histoire: Le Trésor du Pirate ");
    Console.WriteLine("5 => Histoire: La Quête du Dragon d'Or ");
    Console.WriteLine("6 => Histoire: La Légende de l'Épée de Lumière ");
    Console.WriteLine("7 => la Raspberry Pi 4");
    Console.WriteLine("8 => l'Ultimaker S7 (la meilleur histoire si vous faites de limpresion 3D)");
    Console.WriteLine("9 => Le Codeur est la Licorne ");
    return Console.ReadLine();
}

void RaconterUneHistoire(string nomHero, string choix)
{
    if (choix == "1")
    {
        Console.Clear();

        LettreParLettre("histoire 1");
        Console.WriteLine();
        LettreParLettre("alerte alerte ");

        LettreParLettre("au voleur");
        LettreParLettre("on ma volé un gateau");

        LettreParLettre("un(e) hero  apparu");

        LettreParLettre($"le nom(e) de ce hero était {nomHero}");
        LettreParLettre("ils ratrapérent le bandit");
        LettreParLettre("le boulanger dit merci " + nomHero); LettreParLettre("retrouvers les gateau ");
        LettreParLettre("le mangérent ");

        LettreParLettre(" MIAM Miam"); LettreParLettre("dit " + nomHero); Console.ReadKey();


    }
    if (choix == "2")
    {
        Console.Clear();
        Console.WriteLine("Histoire 2 : Le chien abandonné");
        Console.WriteLine($"Un jour, {nomHero} trouva un chien abandonné au bord de la route. Déterminé à lui offrir une nouvelle vie, {nomHero} l'adopta et lui donna le nom de Mambo. Ensemble, ils vécurent de nombreuses aventures et devinrent les meilleurs amis du monde.");
         Console.ReadKey();

    }
    if (choix == "3")
    {
        Console.Clear();
        LettreParLettre($"Dans un monde où les rivières chantaient des mélodies d'antan et les arbres murmuraient des secrets oubliés, se dressait un héros peu ordinaire du nom de {nomHero}. Son nom était une énigme en soi, tout comme ses origines mystérieuses. Il avait été trouvé dans les bras d'une rivière tumultueuse, enveloppé dans une écharpe ornée de symboles anciens.\r\n\r\n{nomHero} avait grandi parmi les sages du village d'Aurélie, où la magie était aussi commune que le souffle du vent. Il était doté d'un don rare : la capacité à communiquer avec les créatures magiques qui peuplaient la forêt environnante. Grâce à ses talents, il était devenu le gardien de la forêt, veillant sur ses habitants avec une bienveillance infinie.\r\n\r\nUn jour, alors que le ciel s'assombrissait et que des ombres menaçantes se profilaient à l'horizon, {nomHero} reçut une vision troublante. Une ancienne force maléfique, emprisonnée depuis des siècles dans les profondeurs de la terre, se préparait à se libérer et à plonger le monde dans les ténèbres éternelles.\r\n\r\nGuidé par son destin, {nomHero} entreprit un voyage périlleux à travers des contrées inconnues, affrontant des monstres terrifiants et des épreuves mortelles. Avec l'aide de ses fidèles compagnons - un  Chiwawa majestueux nommé Mambo, un faucon rapide comme l'éclair appelé Zéphyr, et un esprit de la forêt nommé Sylve - il franchit chaque obstacle avec bravoure et détermination.\r\n\r\nFinalement, après de nombreux défis et sacrifices, {nomHero} atteignit le cœur des ténèbres, là où l'ancienne force maléfique sommeillait. Dans un ultime affrontement épique, il fit appel à tout son courage et à toute sa magie pour sceller à nouveau le mal dans les entrailles de la terre.\r\n\r\nDe retour chez lui, {nomHero} fut accueilli en héros, mais il savait que son voyage n'était pas terminé. Car même dans la paix retrouvée, de nouveaux défis attendaient, et il était prêt à les affronter avec la même bravoure et la même détermination qui l'avaient guidé jusqu'alors.");
    }
    if (choix == "4")
    {
        Console.Clear();

        LettreParLettre("Histoire: Le Trésor du Pirate");
        LettreParLettre("Alerte ! Alerte !");
        LettreParLettre("Les habitants de l'île de Tortuga sont en émoi.");
        LettreParLettre("Un vieux parchemin révélant l'emplacement du trésor légendaire du pirate Barbe Noire a été découvert !");
        LettreParLettre("Un(e) héros/héroïne apparut, prêt(e) à affronter les dangers de la mer.");
        LettreParLettre($"Le nom(e) de ce héros/héroïne est {nomHero}.");
        LettreParLettre("Après une aventure mouvementée et des combats contre des flibustiers, le trésor fut enfin découvert.");
        LettreParLettre($"Le village de Tortuga célébra {nomHero} comme le plus grand(e) pirate de tous les temps !");
        Console.ReadKey();
    }

    if (choix == "5")
    {
        Console.Clear();
        LettreParLettre("Histoire: La Quête du Dragon d'Or");
        LettreParLettre("Une prophétie ancestrale raconte l'existence d'un dragon légendaire, gardien d'un trésor inestimable.");
        LettreParLettre("Ce dragon, fait d'or pur, réside au sommet de la montagne interdite, où nul mortel n'a jamais osé s'aventurer.");
        LettreParLettre("Un(e) héro/héroïne audacieux(se) se leva pour relever le défi de la quête du dragon d'or.");
        LettreParLettre($"Son nom(e) est {nomHero}, et il/elle est prêt(e) à affronter tous les dangers pour réussir sa mission.");
        LettreParLettre("Guidé(e) par sa bravoure et sa détermination, {nomHero} escalada la montagne et défia le dragon.");
        LettreParLettre("Après un combat épique, le dragon, impressionné par son courage, lui céda le trésor.");
        LettreParLettre("Ainsi, {nomHero} devint célèbre dans tout le royaume comme le plus grand chasseur de trésors.");
        Console.ReadKey();
    }

    if (choix == "6")
    {
        Console.Clear();
        LettreParLettre($"Histoire: La Légende de l'Épée de Lumière");
        LettreParLettre($"Dans un monde plongé dans les ténèbres, une légende ancienne raconte l'existence d'une épée légendaire, forgée dans la lumière elle-même.");
        LettreParLettre($"Cette épée, capable de vaincre les forces du mal, attend son héros/héroïne destiné(e) à la manier.");
        LettreParLettre($"Un(e) héro/héroïne courageux(se) se lève pour relever le défi de retrouver l'Épée de Lumière et sauver le monde de l'obscurité éternelle.");
        LettreParLettre($"Son nom(e) est {nomHero}, et son destin est de devenir le(la) gardien(ne) de l'Épée de Lumière.");
        LettreParLettre($"{nomHero}, accompagné(e) de ses fidèles compagnons, entreprend un voyage périlleux à travers des contrées dangereuses.");
        LettreParLettre($"Après de nombreux défis et épreuves, {nomHero} découvre enfin l'Épée de Lumière.");
        LettreParLettre($"Avec cette épée à ses côtés, {nomHero} affronte l'obscurité et ramène la lumière dans le monde.");
        LettreParLettre($"Désormais, {nomHero} est vénéré(e) comme le(la) sauveur(se) de la prophétie, et son nom résonne dans les annales de l'histoire.");
        Console.ReadKey();
    }
    
        if (choix == "7")
    {
        Console.Clear();
        // Histoire 7
        LettreParLettre($"Histoire 1 : Le Mystère de la Raspberry Pi 4");
            LettreParLettre($"Un jour, dans un lointain laboratoire informatique, une Raspberry Pi 4 a mystérieusement disparu.");
            LettreParLettre($"Un(e) héros/héroïne appelé(e) {nomHero} a été appelé(e) pour résoudre ce mystère.");
            LettreParLettre($"{nomHero}, armé(e) de son clavier et de sa souris, a traqué les indices et résolu le mystère de la Raspberry Pi 4 manquante.");
            LettreParLettre($"Grâce à son ingéniosité, {nomHero} a découvert que la Raspberry Pi 4 s'était cachée dans un tas de câbles réseau !");
            LettreParLettre($"Le laboratoire a célébré {nomHero} comme le(la) plus grand(e) détective informatique de tous les temps !");
            Console.ReadKey();
        }
        if (choix == "8")
    {
        Console.Clear();
        // Histoire 8
        LettreParLettre($"Histoire 2 : L'Aventure de l'Ultimaker S7");
            LettreParLettre($"Un(e) if (choix == \"3\")/héroïne intrépide nommé(e) {nomHero} s'est lancé(e) dans une quête pour maîtriser l'Ultimaker S7.");
            LettreParLettre($"{nomHero} a dû affronter des défis redoutables, tels que le calibrage de l'extrudeuse et le nivellement du lit d'impression.");
            LettreParLettre($"Après de nombreuses heures d'essais et d'erreurs, {nomHero} a réussi à imprimer une pièce parfaite !");
            LettreParLettre($"L'Ultimaker S7 a été impressionnée par les compétences de {nomHero} et a accepté de devenir son fidèle allié dans ses futures créations.");
            Console.ReadKey();
        }
        if (choix == "9")
        {
        // Histoire 9
        Console.Clear();
        LettreParLettre("Histoire 3 : Le Codeur et la Licorne");
            LettreParLettre($"Un jour, un codeur nommé {nomHero} rencontra une licorne dans son code.");
            LettreParLettre($"La licorne, se baladant librement dans la matrice de bits, était curieuse de découvrir le monde du code.");
            LettreParLettre($"{nomHero} a enseigné à la licorne les joies du codage, et ensemble, ils ont créé des programmes magiques !");
            LettreParLettre($"Désormais, {nomHero} et la licorne travaillent en tandem, apportant magie et technologie au monde entier.");
            Console.ReadKey();
        }
        // Ajoutez d'autres histoires selon le même schéma
    

}

bool DoitContinuer(string choix)
{
    return choix != "0";
}

void FinDuProgramme()
{
    LettreParLettre("Fin du programme");
    Console.ReadLine();
}

void X(string phrase)
{
    // Random aleatoire = new Random();
    int c = 0;
    foreach (char l in phrase)
    {

        c++;
        Console.Write(l);
        // attendre un temps
        if (c % 8 == 0)
            Thread.Sleep(1);

    }
    Console.WriteLine();
}

static string ChoisirUneAction()
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("Choisie une option ");
    Console.WriteLine("0 => Quitter");
    Console.WriteLine("1 => Histoire");
    Console.WriteLine("2 => Calculatrice");
    Console.WriteLine("3 => Timer ");
    Console.WriteLine("4 => Chrono Beta");
    Console.WriteLine("5 => Snake");
    Console.WriteLine("6 => Histoire en ligne");
    string choixFonction = Console.ReadLine();
    return choixFonction;

}

public class HistoireEnLigne
{
    public int id { get; set; }
    public string titre { get; set; }
    public string contenu { get; set; }
}
public static class Snake
{
    static int width = 40;
    static int height = 20;
    static int score = 0;
    static int speed = 100;
    static bool gameOver = false;
    static Direction direction = Direction.Right;
    static Random random = new Random();
    static List<Position> snake = new List<Position>();
    static Position food = new Position();

    enum Direction
    {
        Left,
        Right,
        Up,
        Down
    }

    struct Position
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    public static void Play()
    {
        Console.CursorVisible = false;

        InitializeGame();
        DrawBoard();

        Thread inputThread = new Thread(MoveSnake);
        inputThread.Start();

        while (!gameOver)
        {
            UpdateGame();
            Thread.Sleep(speed);
        }

        Console.SetCursorPosition(width / 2 - 5, height / 2);
        Console.WriteLine("Game Over!");
        Console.WriteLine($"Score: {score}");
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }

    static void InitializeGame()
    {
        snake.Add(new Position { X = width / 2, Y = height / 2 });

        food = GenerateFoodPosition();
        DrawFood();
    }

    static void DrawBoard()
    {
        Console.Clear();

        // Draw top border
        Console.SetCursorPosition(0, 0);
        Console.WriteLine(new string('#', width + 2));

        // Draw middle
        for (int y = 0; y < height; y++)
        {
            Console.Write("#");
            for (int x = 0; x < width; x++)
            {
                if (snake.Any(s => s.X == x && s.Y == y))
                    Console.Write("O");
                else if (x == food.X && y == food.Y)
                    Console.Write("F");
                else
                    Console.Write(" ");
            }
            Console.WriteLine("#");
        }

        // Draw bottom border
        Console.WriteLine(new string('#', width + 2));
        Console.WriteLine($"Score: {score}");
    }

    static Position GenerateFoodPosition()
    {
        int x = random.Next(0, width);
        int y = random.Next(0, height);

        while (snake.Any(s => s.X == x && s.Y == y))
        {
            x = random.Next(0, width);
            y = random.Next(0, height);
        }

        return new Position { X = x, Y = y };
    }

    static void DrawFood()
    {
        Console.SetCursorPosition(food.X + 1, food.Y + 1);
        Console.Write("F");
    }

    static void MoveSnake()
    {
        while (!gameOver)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            switch (keyInfo.Key)
            {
                case ConsoleKey.LeftArrow:
                    if (direction != Direction.Right)
                        direction = Direction.Left;
                    break;
                case ConsoleKey.RightArrow:
                    if (direction != Direction.Left)
                        direction = Direction.Right;
                    break;
                case ConsoleKey.UpArrow:
                    if (direction != Direction.Down)
                        direction = Direction.Up;
                    break;
                case ConsoleKey.DownArrow:
                    if (direction != Direction.Up)
                        direction = Direction.Down;
                    break;
            }
        }
    }

    static void UpdateGame()
    {
        Position newHead = new Position { X = snake.First().X, Y = snake.First().Y };

        switch (direction)
        {
            case Direction.Left:
                newHead.X--;
                break;
            case Direction.Right:
                newHead.X++;
                break;
            case Direction.Up:
                newHead.Y--;
                break;
            case Direction.Down:
                newHead.Y++;
                break;
        }

        if (newHead.X < 0 || newHead.X >= width || newHead.Y < 0 || newHead.Y >= height || snake.Any(s => s.X == newHead.X && s.Y == newHead.Y))
        {
            gameOver = true;
            return;
        }

        snake.Insert(0, newHead);

        if (newHead.X == food.X && newHead.Y == food.Y)
        {
            score++;
            food = GenerateFoodPosition();
            DrawFood();

        }
        else
        {
            Console.SetCursorPosition(snake.Last().X + 1, snake.Last().Y + 1);
            Console.Write(" ");
            snake.RemoveAt(snake.Count - 1);
        }

        DrawBoard();
    }
}
