using System.Text.Json;
using Ultra_Launcher;
Console.BackgroundColor = ConsoleColor.Black;
Console.ForegroundColor = ConsoleColor.DarkYellow;


bool DebugModeOFF = true; //debug mode on = false
bool PromptON = true;
bool LetreparletreOFF = false;
string paramNom = "Name=";
string paramGenre = "Genre=";
string cheminFichier = "options.txt";
await UltraLauncher();



void SauveNom(string nouveauNom)
{
    try
    {
        using (StreamWriter writer = File.AppendText(cheminFichier))
        {
            writer.WriteLine($"{paramNom}{nouveauNom}");
        }
        Console.WriteLine($"Nouveau nom sauvé {nouveauNom} dans le fichier {cheminFichier}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Une erreur s'est produite lors de la sauvegarde du nom : {ex.Message}");
    }
}

void SauveGenre(string nouveauGenre)
{
    try
    {
        using (StreamWriter writer = File.AppendText(cheminFichier))
        {
            writer.WriteLine($"{paramGenre}{nouveauGenre}");
        }
        Console.WriteLine($"Nouveau genre sauvé {nouveauGenre} dans le fichier {cheminFichier}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Une erreur s'est produite lors de la sauvegarde du genre : {ex.Message}");
    }
}



string RecupererNomSauve()
{
    try
    {
        if (!File.Exists(cheminFichier)) return string.Empty; // Aucun nom enregistré

        string? ligneNom = File.ReadLines(cheminFichier)
        .FirstOrDefault(ligne => ligne.StartsWith(paramNom));

        if (ligneNom == null) return string.Empty; // Aucun nom enregistré

        string nom = ligneNom[paramNom.Length..];

        return nom;
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Une erreur s'est produite lors de la lecture du fichier : {ex.Message}");
        return string.Empty;
    }
}
string RecupererGenreSauve()
{
    try
    {
        if (!File.Exists(cheminFichier)) return string.Empty; // Aucun Genre enregistré

        string? ligneGenre = File.ReadLines(cheminFichier)
        .FirstOrDefault(ligne => ligne.StartsWith(paramGenre));

        if (ligneGenre == null) return string.Empty; // Aucun Genre enregistré

        string Genre1 = ligneGenre[paramNom.Length..];

        return Genre1;
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Une erreur s'est produite lors de la lecture du fichier : {ex.Message}");
        return string.Empty;
    }
}


void YellowBackground()
{
    Console.ForegroundColor = ConsoleColor.Black;
    Console.BackgroundColor = ConsoleColor.Yellow;
    
}


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

            case "2":
                Console.Title = "Calculatrice";
                Calculatrice();
                break;

            case "3":
                Console.Title = "Timer";
                Console.Clear();
                Timer(DebugModeOFF);
                break;

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

            case "5":
                Console.Clear();
                LettreParLettre("en attente De Mise A jour De Contenu ");
                break;

            case "6":
                Console.Clear();
                await AppelApi();
                break;
                
            case "p":
                Console.Clear();
                Console.WriteLine(@"                                                                                         
▀███▀▀▀██▄                                                           ██                  
  ██   ▀██▄                                                          ██                  
  ██   ▄██ ▄█▀██▄ ▀███▄███ ▄█▀██▄ ▀████████▄█████▄   ▄▄█▀██▀███▄█████████  ▄▄█▀██ ▄██▀███
  ███████ ██   ██   ██▀ ▀▀██   ██   ██    ██    ██  ▄█▀   ██ ██▀ ▀▀  ██   ▄█▀   ████   ▀▀
  ██       ▄█████   ██     ▄█████   ██    ██    ██  ██▀▀▀▀▀▀ ██      ██   ██▀▀▀▀▀▀▀█████▄
  ██      ██   ██   ██    ██   ██   ██    ██    ██  ██▄    ▄ ██      ██   ██▄    ▄█▄   ██
▄████▄    ▀████▀██▄████▄  ▀████▀██▄████  ████  ████▄ ▀█████▀████▄    ▀████ ▀█████▀██████▀");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("1. Changer le Nom Enregistré ");
                Console.WriteLine("2. Changer la Couleur du Texte (non  Dispo Pour cette version du progarme)");
             
                Console.WriteLine("3. Changer la Couleur de Fond (non  Dispo Pour cette version du progarme)");
           
                Console.Write("Entrez votre choix : ");
                string option = Console.ReadLine();

                switch (option)
                {

            case "1":
               SaisirNomHero(forceChange: true);
                       
                        Console.Clear();
                        PromptON = false;
                        Console.BackgroundColor = ConsoleColor.Black;

                        await UltraLauncher();
                        break;
                    case "2":
                        // Changer la couleur du texte
                        Console.WriteLine("Voici la liste des couleurs disponibles pour le texte :");
                        for (int i = 0; i < 16; i++) // Il y a 16 couleurs de texte
                        {
                            Console.ForegroundColor = (ConsoleColor)i;
                            Console.WriteLine($"{i}: Texte de couleur {(ConsoleColor)i}");
                        }
                        Console.ResetColor();
                        Console.WriteLine("Entrez le numéro de la couleur du texte que vous souhaitez utiliser : ");
                        if (int.TryParse(Console.ReadLine(), out int textColorIndex) && textColorIndex >= 0 && textColorIndex < 16)
                        {
                            Console.ForegroundColor = (ConsoleColor)textColorIndex;
                            Console.WriteLine("Couleur du texte changée !");
                            PromptON = false;
                            UltraLauncher();
                        }
                        else
                        {
                            Console.WriteLine("Numéro de couleur du texte non valide !");
                        }
                        Console.ResetColor();
                        break;
                    case "3":
                        Console.ForegroundColor = ConsoleColor.Black;
                        // Changer la couleur de fond
                        Console.WriteLine("Voici la liste des couleurs disponibles pour le fond :");
                        for (int i = 0; i < 16; i++) // Il y a 16 couleurs de fond
                        {
                            Console.BackgroundColor = (ConsoleColor)i;
                            Console.WriteLine($"{i}: Couleur de fond {(ConsoleColor)i}");
                        }
                        Console.ResetColor();
                        Console.WriteLine("Entrez le numéro de la couleur de fond que vous souhaitez utiliser : ");
                        if (int.TryParse(Console.ReadLine(), out int backColorIndex) && backColorIndex >= 0 && backColorIndex < 16)
                        {
                            Console.BackgroundColor = (ConsoleColor)backColorIndex;
                            Console.Clear();
                            Console.WriteLine("Couleur de fond changée !");
                            PromptON = false;
                                UltraLauncher();
                        }
                        else
                        {
                            Console.WriteLine("Numéro de couleur de fond non valide !");
                        }
                        Console.ResetColor();
                        break;
                    
                        // Choisir un thème de couleur
                        Console.WriteLine("Voici quelques thèmes  :");
                        Console.WriteLine("1: Thème Clair");
                        Console.WriteLine("2: Thème Sombre");
                        Console.WriteLine("Entrez le numéro du thème que vous souhaitez utiliser : ");
                        if (int.TryParse(Console.ReadLine(), out int themeChoice))
                        {
                            switch (themeChoice)
                            {
                                case 1:
                                    // Thème Clair : Fond Blanc, Texte Noir
                                       Console.ForegroundColor = ConsoleColor.Black;
                                    Console.BackgroundColor = ConsoleColor.White;
                                 
                                    Console.Clear();
                                    Console.WriteLine("Thème Clair activé !");
                                    PromptON = false;
                                    UltraLauncher();
                                    break;
                                case 2:
                                    // Thème Sombre : Fond Noir, Texte Blanc
                                    Console.BackgroundColor = ConsoleColor.Black;
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Clear();
                                    Console.WriteLine("Thème Sombre activé !");
                                    PromptON = false;
                                    UltraLauncher();
                                    break;
                                default:
                                    Console.WriteLine("Numéro de thème non valide !");
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Numéro de thème non valide !");
                        }
                        Console.ResetColor();
                        break;
                }

                break;

            default:
                Console.Clear();
                PromptON = false;
                await UltraLauncher();
                return;
        }

        FinDuProgramme();
    }
    else
    {
        PromptON = false;
        DebugModeOFF = true;
        await UltraLauncher();
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
    
    
    X(@"
 ██████╗ █████╗ ██╗      ██████╗██╗   ██╗██╗      █████╗ ████████╗██████╗ ██╗ ██████╗███████╗
██╔════╝██╔══██╗██║     ██╔════╝██║   ██║██║     ██╔══██╗╚══██╔══╝██╔══██╗██║██╔════╝██╔════╝
██║     ███████║██║     ██║     ██║   ██║██║     ███████║   ██║   ██████╔╝██║██║     █████╗  
██║     ██╔══██║██║     ██║     ██║   ██║██║     ██╔══██║   ██║   ██╔══██╗██║██║     ██╔══╝  
╚██████╗██║  ██║███████╗╚██████╗╚██████╔╝███████╗██║  ██║   ██║   ██║  ██║██║╚██████╗███████╗
 ╚═════╝╚═╝  ╚═╝╚══════╝ ╚═════╝ ╚═════╝ ╚══════╝╚═╝  ╚═╝   ╚═╝   ╚═╝  ╚═╝╚═╝ ╚═════╝╚══════╝
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

        Console.WriteLine("Voulez-vous continuer? (O/N)");
        string continuer = Console.ReadLine();

        if (continuer.ToLower() != "o")
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
    YellowBackground();
    string nomHero = SaisirNomHero();
    Genre genre = SaisirGenre();

   
    string choix = ChoisirUneHistoire(nomHero);

    while (DoitContinuer(choix))
    {
        RaconterUneHistoire(nomHero, choix , genre);
        choix = ChoisirUneHistoire(nomHero);
    }
}

string SaisirNomHero(bool forceChange=false)
{
    if (!forceChange)
    {
        string nomHeroSauve = RecupererNomSauve();
        if (!string.IsNullOrWhiteSpace(nomHeroSauve)) return nomHeroSauve;
    }

    string nouveauNom = "";
    Console.Clear();
    YellowBackground();

    string userName = Environment.UserName;
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.BackgroundColor = ConsoleColor.Black;
    Console.CursorVisible = false;
    ConsoleKeyInfo key2;
    int selectedIndex2 = 0;
    string[] options = { "Nom d'utilisateur Du pc :" + userName, "Nouveau nom d'utilisateur " };

    do
    {
        Console.Clear();
        Console.WriteLine("Sélectionner votre nom D'utilisateur");

        for (int i2 = 0; i2 < options.Length; i2++)
        {
            if (i2 == selectedIndex2)
            {
                YellowBackground();
                Console.Write(" > ");
            }
            else
            {

                Console.Write("   ");
            }
            Console.WriteLine(options[i2]);
            Console.ResetColor();
        }

        key2 = Console.ReadKey(true);

        if (key2.Key == ConsoleKey.UpArrow)
        {
            selectedIndex2 = (selectedIndex2 == 0) ? options.Length - 1 : selectedIndex2 - 1;
        }
        else if (key2.Key == ConsoleKey.DownArrow)
        {
            selectedIndex2 = (selectedIndex2 == options.Length - 1) ? 0 : selectedIndex2 + 1;
        }

    } while (key2.Key != ConsoleKey.Enter);

    Console.Clear();

    if (selectedIndex2 == 0)
        Console.CursorVisible = true;
    {
        Console.ForegroundColor = ConsoleColor.Black;
        Console.BackgroundColor = ConsoleColor.Yellow;
        nouveauNom = userName;
    }
    if (selectedIndex2 == 1)
    {
        Console.CursorVisible = true;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.BackgroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Saisissez le Nouveau nom d'utilisateur ");
        Console.Write("> ");
        nouveauNom = Console.ReadLine() ?? string.Empty;
    }

    SauveNom(nouveauNom);
    return nouveauNom;
}


//Genre SaisirGenre(bool forceChange = false)
//{
//    if (!forceChange)
//    {
//        //Genre genreSauve = RecupererGenreSauve();
//        if (genreSauve != Genre.NonBinaire)
//        {
//            Console.WriteLine($"Genre sauvegardé trouvé : {genreSauve}");
//            return genreSauve;
//        }
//    }
   
//    Console.CursorVisible = false;
//    ConsoleKeyInfo key;
//    int selectedIndex = 0;
//    Genre[] options = { Genre.Masculin, Genre.Feminin, Genre.NonBinaire };

//    do
//    {
//        Console.Clear();
//        Console.WriteLine("Choisissez le genre de votre personnage :");
    
//        for (int i = 0; i < options.Length; i++)
//        {
//            if (i == selectedIndex)
//            {
//                Console.BackgroundColor = ConsoleColor.Yellow;
//                Console.ForegroundColor = ConsoleColor.Black;
//                Console.Write(" > ");
//            }
//            else
//            {
//                Console.Write("   ");
//            }
//            Console.WriteLine(options[i]);
//            Console.ResetColor();
//        }

//        key = Console.ReadKey(true);

//        if (key.Key == ConsoleKey.UpArrow)
//        {
//            selectedIndex = (selectedIndex == 0) ? options.Length - 1 : selectedIndex - 1;
//        }
//        else if (key.Key == ConsoleKey.DownArrow)
//        {
//            selectedIndex = (selectedIndex == options.Length - 1) ? 0 : selectedIndex + 1;
//        }

//    } while (key.Key != ConsoleKey.Enter);

//    Console.CursorVisible = true;
//    Console.Clear();
//    Console.WriteLine("Vous avez choisi : " + options[selectedIndex]);

//    return options[selectedIndex];
//}



string ChoisirUneHistoire(string nomHero)
{
    //ChoixLangue choixLangue = new ChoixLangue();
  //  string langueChoisie = choixLangue.ChoisirLangue();

    YellowBackground();
    //if (langueChoisie == "fr")
    //{
        YellowBackground();
        Console.Clear();
        X(@"

$$\   $$\ $$\             $$\               $$\                               
$$ |  $$ |\__|            $$ |              \__|                              
$$ |  $$ |$$\  $$$$$$$\ $$$$$$\    $$$$$$\  $$\  $$$$$$\   $$$$$$\   $$$$$$$\ 
$$$$$$$$ |$$ |$$  _____|\_$$  _|  $$  __$$\ $$ |$$  __$$\ $$  __$$\ $$  _____|
$$  __$$ |$$ |\$$$$$$\    $$ |    $$ /  $$ |$$ |$$ |  \__|$$$$$$$$ |\$$$$$$\  
$$ |  $$ |$$ | \____$$\   $$ |$$\ $$ |  $$ |$$ |$$ |      $$   ____| \____$$\ 
$$ |  $$ |$$ |$$$$$$$  |  \$$$$  |\$$$$$$  |$$ |$$ |      \$$$$$$$\ $$$$$$$  |
\__|  \__|\__|\_______/    \____/  \______/ \__|\__|       \_______|\_______/ 

 ");
        Console.WriteLine("Choisi une histoire " + nomHero);
        Console.WriteLine("0 => Quitter");
        Console.WriteLine("1 => Histoire: le gateau");
        Console.WriteLine("2 => Le chien abandonné");
        Console.WriteLine("3 => Le Hero");
        Console.WriteLine("4 => Histoire: Le Trésor du Pirate ");
        Console.WriteLine("5 => Histoire: La Quête du Dragon d'Or ");
        Console.WriteLine("6 => Histoire: La Légende de l'Épée de Lumière ");
        Console.WriteLine("7 => la Raspberry Pi 4");
        Console.WriteLine("8 => l'Ultimaker S7  ");
        Console.WriteLine("9 => Le Codeur est la Licorne ");

        Console.Write("> ");

   //}

//   // else if (langueChoisie == "en")
//    {
//        Console.Clear ();
//        X(@"
//            $$\                                   
//            $$ |                                  
// $$$$$$$\ $$$$$$\    $$$$$$\   $$$$$$\  $$\   $$\ 
//$$  _____|\_$$  _|  $$  __$$\ $$  __$$\ $$ |  $$ |
//\$$$$$$\    $$ |    $$ /  $$ |$$ |  \__|$$ |  $$ |
// \____$$\   $$ |$$\ $$ |  $$ |$$ |      $$ |  $$ |
//$$$$$$$  |  \$$$$  |\$$$$$$  |$$ |      \$$$$$$$ |
//\_______/    \____/  \______/ \__|       \____$$ |
//                                        $$\   $$ |
//                                        \$$$$$$  |
//                                         \______/ 


//");
//        Console.WriteLine("Choose a story ");
//        Console.WriteLine("0 => Exit");
//        Console.WriteLine("1 => Story: the cake");
//        Console.WriteLine("2 => The abandoned dog");
//        Console.WriteLine("3 => The Hero");
//        Console.WriteLine("4 => Story: The Pirate's Treasure ");
//        Console.WriteLine("5 => Story: The Quest for the Golden Dragon ");
//        Console.WriteLine("6 => History: The Legend of the Sword of Light ");
//        Console.WriteLine("7 => the Raspberry Pi 4");
//        Console.WriteLine("8 => Ultimaker S7 ");
//        Console.WriteLine("9 => The Coder is the Unicorn ");
//        Console.WriteLine("P => Parameters");
//        Console.Write("> ");

//    }

    string choix = Console.ReadLine();
    return choix;
}



void RaconterUneHistoire(string nomHero, string choix, Genre genre)
{

    IReadOnlyList<string> histoireFR = choix switch
    {
        "1" => new List<string>
        {
            "histoire 1", "", "alerte alerte ", "au voleur", "on m'a volé un gâteau", "un héros  apparu", $"le nom de ce héros était {nomHero}",
            "ils rattrapèrent le bandit", $"le boulanger dit merci {(genre == Genre.Feminin ? "à" : "au")} " + nomHero, "Ils retrouvèrent les gâteaux ", "et les mangèrent ",
            " MIAM Miam", $"dit {nomHero}"
        },
        "2" => new List<string>
        {
            $"Histoire 2 : Le chien abandonné", "", $"Un jour, {nomHero} trouva un chien abandonné au bord de la route. Déterminé à lui offrir une nouvelle vie, {nomHero} l'adopta et lui donna le nom de Mambo. Ensemble, ils vécurent de nombreuses aventures et devinrent les meilleurs amis du monde."
        },

        
        _ => new List<string>() // Par défaut, une liste vide
    };

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
        LettreParLettre($"Un(e) Héro/héroïne intrépide nommé(e) {nomHero} s'est lancé(e) dans une quête pour maîtriser l'Ultimaker S7.");
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
    IReadOnlyList<string> histoireEN = choix switch
    {
        "1" => new List<string>
        {
            "histoire 1", "", "alerte alerte ", "au voleur", "on m'a volé un gâteau", "un héros  apparu", $"le nom de ce héros était {nomHero}",
            "ils rattrapèrent le bandit", $"le boulanger dit merci {(genre == Genre.Feminin ? "à" : "au")} " + nomHero, "Ils retrouvèrent les gâteaux ", "et les mangèrent ",
            " MIAM Miam", $"dit {nomHero}"
        },
        "2" => new List<string>
        {
            $"Histoire 2 : Le chien abandonné", "", $"Un jour, {nomHero} trouva un chien abandonné au bord de la route. Déterminé à lui offrir une nouvelle vie, {nomHero} l'adopta et lui donna le nom de Mambo. Ensemble, ils vécurent de nombreuses aventures et devinrent les meilleurs amis du monde."
        },
        // Ajoutez d'autres histoires ici selon le même modèle
        _ => new List<string>() // Par défaut, une liste vide
    };

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
        LettreParLettre($"Un(e) Héro/héroïne intrépide nommé(e) {nomHero} s'est lancé(e) dans une quête pour maîtriser l'Ultimaker S7.");
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

    Console.Clear();
    foreach (string phrase in histoireEN)
    {
        if (genre == Genre.Feminin)
        {
            LettreParLettre(phrase.Replace("un héros", "une héroïne")
                .Replace("ce héros", "cette héroïne"));
        }
        else
        {
            LettreParLettre(phrase);
        }
    }
    Console.ReadKey();
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
    Console.WriteLine("p => Paramètres");

    Console.Write("> ");
    string choixFonction = Console.ReadLine().ToLower();
    return choixFonction;
}

public class HistoireEnLigne
{
    public int id { get; set; }
    public string titre { get; set; }
    public string contenu { get; set; }
}
 class Snake
{

    
}
