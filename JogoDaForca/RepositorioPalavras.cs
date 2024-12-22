using System;
using System.Collections.Generic;

namespace JogoDaForca
{
    // Nessa classe criamos uma List (Lista) do tipo PalavraComDica, chamada _palavras.
    // A seguir populamos essa lista com várias palavras e dicas.
    // Por fim sorteamos uma posição dessa lista e retornamos um objeto do tipo PalavraComDica
    public class RepositorioPalavras
    {
        private List<PalavraComDica> _palavras;

        public RepositorioPalavras()
        {
            _palavras = new List<PalavraComDica>
            {
                new PalavraComDica("fruta vermelha e suculenta", "maçã"),
                new PalavraComDica("imagem capturada por uma câmera", "fotografia"),
                new PalavraComDica("elevação natural da terra", "montanha"),
                new PalavraComDica("esporte jogado com uma bola e pés", "futebol"),
                new PalavraComDica("planta de flor grande que segue o sol", "girassol"),
                new PalavraComDica("meio de comunicação para transmitir programas", "televisão"),
                new PalavraComDica("veículo de duas rodas movido por pedal", "bicicleta"),
                new PalavraComDica("área cultivada com flores e plantas", "jardim"),
                new PalavraComDica("instrumento musical de cordas", "violão"),
                new PalavraComDica("viajante espacial", "astronauta"),
                new PalavraComDica("inseto que produz mel", "abelha"),
                new PalavraComDica("dispositivo para medir o tempo", "relógio"),
                new PalavraComDica("animal de estimação leal", "cachorro"),
                new PalavraComDica("local que abriga livros e recursos de leitura", "biblioteca"),
                new PalavraComDica("fenômeno óptico com cores do espectro", "arco-íris"),
                new PalavraComDica("doce feito a partir de cacau e açúcar", "chocolate"),
                new PalavraComDica("utensílio para bebidas quentes", "xícara"),
                new PalavraComDica("extensão de água salgada que cobre grande parte da Terra", "oceano"),
                new PalavraComDica("pessoa que toca piano", "pianista"),
                new PalavraComDica("mamífero terrestre de grande porte com presas longas", "elefante"),
                new PalavraComDica("local para apresentações ao vivo", "teatro"),
                new PalavraComDica("meio de transporte que voa no ar", "avião"),
                new PalavraComDica("fruta pequena e vermelha", "cereja"),
                new PalavraComDica("satélite natural da Terra", "lua"),
                new PalavraComDica("fonte de luz com pavio", "vela"),
                new PalavraComDica("dispositivo eletrônico para processamento de dados", "computador"),
                new PalavraComDica("dispositivo de comunicação por voz", "telefone"),
                new PalavraComDica("instituição de ensino superior", "universidade"),
                new PalavraComDica("conjunto de partículas de água ou gelo no céu", "nuvem"),
                new PalavraComDica("local para exibição de filmes", "cinema"),
                new PalavraComDica("refeição principal do dia", "almoço"),
                new PalavraComDica("calçado para os pés", "sapato"),
                new PalavraComDica("expressão artística sonora", "música"),
                new PalavraComDica("aeronave com hélices rotativas", "helicóptero"),
                new PalavraComDica("animal de quatro patas usado para montaria", "cavalo"),
                new PalavraComDica("saqueador dos mares", "pirata"),
                new PalavraComDica("instrumento de escrita", "caneta"),
                new PalavraComDica("esporte de equipe jogado com uma bola", "vôlei"),
                new PalavraComDica("fruta cítrica", "laranja"),
                new PalavraComDica("superfície refletora de vidro", "espelho"),
                new PalavraComDica("veículo espacial impulsionado por motores", "foguete"),
                new PalavraComDica("local de culto religioso", "igreja"),
                new PalavraComDica("abertura em uma parede para luz e ventilação", "janela"),
                new PalavraComDica("felino selvagem de listras", "tigre"),
                new PalavraComDica("instituição de ensino", "escola"),
                new PalavraComDica("expressão artística do movimento do corpo", "dança"),
                new PalavraComDica("região seca com pouca vegetação", "deserto"),
                new PalavraComDica("prato de massa com coberturas", "pizza"),
                new PalavraComDica("espetáculo com artistas e animais", "circo"),
                new PalavraComDica("parque que exibe animais", "zoológico"),
                new PalavraComDica("estação mais fria do ano", "inverno"),
                new PalavraComDica("acessório de cabeça", "chapéu"),
                new PalavraComDica("aparelho para cozinhar alimentos", "fogão"),
                new PalavraComDica("produto alimentício da galinha", "ovo"),
                new PalavraComDica("meio de comunicação por ondas", "rádio"),
                new PalavraComDica("planta de grande porte com tronco", "árvore"),
                new PalavraComDica("veículo de transporte público", "ônibus"),
                new PalavraComDica("área de água para natação", "piscina"),
                new PalavraComDica("viajante espacial", "astronauta"),
                new PalavraComDica("ave com penas e asas", "pássaro"),
                new PalavraComDica("meio de transporte que voa no ar", "avião"),
                new PalavraComDica("estrutura alta e vertical", "torre"),
                new PalavraComDica("instrumento musical de cordas", "guitarra"),
                new PalavraComDica("mamífero primata", "gorila"),
                new PalavraComDica("arte corporal permanente", "tatuagem"),
                new PalavraComDica("bebida estimulante", "café"),
                new PalavraComDica("peça dura na boca", "dente"),
                new PalavraComDica("meio de comunicação impresso", "jornal"),
                new PalavraComDica("local para apresentações ao vivo", "teatro"),
                new PalavraComDica("veículo de duas rodas movido por pedal", "bicicleta"),
                new PalavraComDica("mamífero terrestre de grande porte com presas longas", "elefante"),
                new PalavraComDica("local de culto religioso", "igreja"),
                new PalavraComDica("área extensa de árvores e vegetação", "floresta"),
                new PalavraComDica("profissional de saúde", "enfermeiro"),
                new PalavraComDica("recipiente para plantas", "vaso"),
                new PalavraComDica("produto de cuidado capilar", "xampu"),
                new PalavraComDica("satélite natural da Terra", "lua"),
                new PalavraComDica("fonte de luz com pavio", "vela"),
                new PalavraComDica("animal de quatro patas usado para montaria", "cavalo"),
                new PalavraComDica("doce feito a partir de cacau e açúcar", "chocolate"),
                new PalavraComDica("dispositivo eletrônico para processamento de dados", "computador"),
                new PalavraComDica("meio de transporte que voa no ar", "avião"),
                new PalavraComDica("local que abriga livros e recursos de leitura", "biblioteca"),
                new PalavraComDica("conjunto de partículas de água ou gelo no céu", "nuvem")
            };
        }

        private int _ultimoNumeroSorteado = -1;

        public PalavraComDica Sorteia()
        {
            Random rand = new Random();
            int numeroSorteado;

            do
            {
                numeroSorteado = rand.Next(_palavras.Count);
            }
            while (numeroSorteado == _ultimoNumeroSorteado);

            _ultimoNumeroSorteado = numeroSorteado;

            return _palavras[numeroSorteado];
        }

    }
}
