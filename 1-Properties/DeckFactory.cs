namespace Properties
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// A factory class for building <see cref="ISet{T}">decks</see> of <see cref="Card"/>s.
    /// </summary>
    public class DeckFactory
    {
        private string[] _seeds;

        private string[] _names;

        public IList<string> Seeds
        {
            get => _seeds.ToList();
            set => _seeds = value.ToArray();
        }
        
        public IList<string> Names
        {
            get => _names.ToList();
            set => _names = value.ToArray();
        }

        public int GetDeckSize() => Names.Count * _seeds.Length;

        /// TODO improve
        public ISet<Card> GetDeck()
        {
            if (_names == null || _seeds == null)
            {
                throw new InvalidOperationException();
            }

            return new HashSet<Card>(Enumerable
                .Range(0, Names.Count)
                .SelectMany(i => Enumerable
                    .Repeat(i, Seeds.Count)
                    .Zip(
                        Enumerable.Range(0, Seeds.Count),
                        (n, s) => Tuple.Create(Names[n], Seeds[s], n)))
                .Select(tuple => new Card(tuple))
                .ToList());
        }
    }
}
