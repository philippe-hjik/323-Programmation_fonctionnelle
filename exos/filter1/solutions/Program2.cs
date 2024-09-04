// Les mots

List<string> words = new List<string>{ "bonjour", "hello", "supernova", "billyboybeatsme", "rouge", "bleu", "jaune" };

// percentage, according to chatGPT
Dictionary<char, double> frequencies = new Dictionary<char, double>
{
    { 'a', 7.636 },
    { 'b', 0.901 },
    { 'c', 3.260 },
    { 'd', 3.669 },
    { 'e', 14.715 },
    { 'f', 1.066 },
    { 'g', 0.866 },
    { 'h', 0.737 },
    { 'i', 7.529 },
    { 'j', 0.613 },
    { 'k', 0.049 },
    { 'l', 5.456 },
    { 'm', 2.968 },
    { 'n', 7.095 },
    { 'o', 5.796 },
    { 'p', 2.521 },
    { 'q', 1.362 },
    { 'r', 6.553 },
    { 's', 7.948 },
    { 't', 7.244 },
    { 'u', 6.311 },
    { 'v', 1.628 },
    { 'w', 0.114 },
    { 'x', 0.387 },
    { 'y', 0.308 },
    { 'z', 0.136 }
};

double Epsilon (string word, Dictionary<char, double> frequencies)
{
    return word
        .GroupBy(c => c)
        .ToDictionary(group => group.Key, group => group.Count())
        .Sum(c => frequencies[c.Key] /100.0 / c.Value);
}

words
    .Where(w =>
    {
        double e = Epsilon(w, frequencies);
        return e >= 0.5 && e <= 0.97;
    })
    .ToList()
    .ForEach(word => Console.WriteLine(word));

Console.ReadLine();
