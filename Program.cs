using System.Diagnostics;
using System.Text.Json;

bool demo = true; //debug mode on = false
await UltraLauncher();

async Task UltraLauncher()
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
            Timer(demo);

            break;
        default: break;
    }

    switch (choixFonction)
    {
        case "4":
            Console.WriteLine("seconde: ");
            int chrono = 0;
            Console.Title = "Chrono";
            while (true)
            {
                chrono++;
                Console.WriteLine($"seconde:{chrono}");
                Thread.Sleep(1000);
                Console.Clear();
            }
            break;
        default: break;
    }
    switch (choixFonction)
    {
        case "5":
            Console.Clear();
            LancerLeProgramme();

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

void LettreParLettre(string phrase)
{
    Random aleatoire = new Random();

    if (demo)
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
    else
    {
        string c = phrase;
        Console.WriteLine(c);
    }
    // v2 attendre un temps aléatoire entre 0.1s et 1 s
}

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
    
    Console.Beep();
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

static void LancerLeProgramme()
{

    string executablePath = @"C:\git\Ultra-Launcher\game and oters aplication est fichier iniore\consoleGame1\consoleGame1\bin\Debug\net7.0\consoleGame1.exe";

    ProcessStartInfo processStartInfo = new ProcessStartInfo(executablePath);
    processStartInfo.WorkingDirectory = @"C:\git\Ultra-Launcher\game and oters aplication est fichier iniore\consoleGame1\consoleGame1\bin\Debug\net7.0";

    Process.Start(processStartInfo);
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

    Console.ForegroundColor = ConsoleColor.Blue;
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
    return Console.ReadLine();
}

void RaconterUneHistoire(string nomHero, string choix)
{
    if (choix == "1")
    {

        Console.ForegroundColor = ConsoleColor.DarkYellow;
        LettreParLettre("histoire 1");
        Console.WriteLine();
        LettreParLettre("alerte alerte ");

        LettreParLettre("au voleur");
        LettreParLettre("on ma volé un gateau");

        LettreParLettre("un(e) hero  apparu");

        LettreParLettre("le nom(e) de ce hero était {nomHero}");
        LettreParLettre("ils ratrapérent le bandit");
        LettreParLettre("le boulanger dit merci " + nomHero); LettreParLettre("retrouvers les gateau ");
        LettreParLettre("le mangérent ");

        LettreParLettre(" MIAM Miam"); LettreParLettre("dit " + nomHero); Console.ReadKey();


    }
    if (choix == "2")
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        LettreParLettre("histoire: Le Chien abandonné");
        LettreParLettre(" Alerte Alerte   ");
        LettreParLettre("Un Chien a été abandonné");
        LettreParLettre("c" + "e" + "s" + "t" + "un chihuahua, il est a la s.p.a");

        LettreParLettre("un(e) hero  apparu");

        LettreParLettre("le nom(e) de ce hero est " + nomHero);

        LettreParLettre("Heresement  le Hero est cool ");
        LettreParLettre(nomHero + " adopta Mambo");
        LettreParLettre("mabo joua toute l apres midi avec " + nomHero);
        LettreParLettre(nomHero + " est mambo sont super amis mitemenp"); Console.ReadKey();

    }
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
    Console.WriteLine("3 => Timer Beta");
    Console.WriteLine("4 => Chrono Beta");
    Console.WriteLine("5 => Jeu  video : en cours de codage ");
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
