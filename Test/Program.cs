// See https://aka.ms/new-console-template for more information

        int min = 1;                // minimálna hodnota čísiel
        int max = 10;               // (max - 1) - maximálna hodnota čísiel
        int throws = 1000000;       // počet

        int[] vals = new int[max + 1];

        // Generovani cisel
        Random rand = new Random();
        for (int i = 0; i < throws; i++) vals[rand.Next(min, max + 1)]++;

        // Vypis opakujicich se cisel
        for (int i = min; i <= max; i++){
            if(vals[i] > 1) Console.WriteLine("Cislo {0} se opakuje {1}x", i, vals[i]);
        }

