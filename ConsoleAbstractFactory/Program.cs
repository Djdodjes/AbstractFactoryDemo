// GEORGES DAMIEN
namespace ConsoleAbstractFactory
{
    using System;

    /// <summary>
    /// PRogramme console exemple d'implémentation de l'abstact Factory
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {

            // Abstract factory #1
            AbstractFactoryEngin MarquesFrancaises = new ConcreteFactoryFrancaise();
            VerifyMoteur qualiteFrancaise = new VerifyMoteur(MarquesFrancaises);
            qualiteFrancaise.Run();

            // Abstract factory #2
            AbstractFactoryEngin MarquesAllemandes = new ConcreteFactoryAllemande();
            VerifyMoteur qualiteAllemande = new VerifyMoteur(MarquesAllemandes);
            qualiteAllemande.Run();

            // Wait for user input
            Console.ReadKey();
        }



        /// <summary>
        /// AbstractFactory abstract class
        /// </summary>
        abstract class AbstractFactoryEngin
        {
            public abstract AbstractMoteur GetMoteurMarque();
            public abstract AbstractVoiture CreateVoiture();
        }


        /// <summary>
        /// The ConcreteFactory class 1
        /// </summary>
        class ConcreteFactoryFrancaise : AbstractFactoryEngin
        {
            public override AbstractMoteur GetMoteurMarque()
            {
                return new MoteurRenault();
            }
            public override AbstractVoiture CreateVoiture()
            {
                return new VoituresFrancaises();
            }
        }

        /// <summary>
        /// The ConcreteFactory class 2
        /// </summary>
        class ConcreteFactoryAllemande : AbstractFactoryEngin
        {
            public override AbstractMoteur GetMoteurMarque()
            {
                return new MoteurAudi();
            }
            public override AbstractVoiture CreateVoiture()
            {
                return new VoituresAllemandes();
            }
        }

        /// <summary>
        /// classe moto abstract
        /// </summary>
        abstract class AbstractMoteur
        {
        }

        /// <summary>
        /// AbstractVoiture abstract class
        /// </summary>
        abstract class AbstractVoiture
        {
            public abstract void Compare(AbstractMoteur a);
        }


        /// <summary>
        /// ProductA1 class
        /// </summary>
        class MoteurRenault : AbstractMoteur
        {
        }

        /// <summary>
        /// ProductB1 class
        /// </summary>
        class VoituresFrancaises : AbstractVoiture
        {
            public override void Compare(AbstractMoteur a)
            {
                Console.WriteLine("Les " + this.GetType().Name +
                  " disposent d'un moteur " + a.GetType().Name + " et sont de qualité moyenne.");
            }
        }

        /// <summary>
        /// ProductA2 class
        /// </summary>
        class MoteurAudi : AbstractMoteur
        {
        }

        /// <summary>
        /// ProductB2 class
        /// </summary>
        class VoituresAllemandes : AbstractVoiture
        {
            public override void Compare(AbstractMoteur a)
            {
                Console.WriteLine("Les " + this.GetType().Name +
                 " disposent d'un moteur " + a.GetType().Name + " et sont de meilleur qualité.");
            }
        }

        /// <summary>
        /// The Client class
        /// </summary>
        class VerifyMoteur
        {
            private AbstractMoteur _abstractMoteur;
            private AbstractVoiture _abstractVoiture;

            // Constructor
            public VerifyMoteur(AbstractFactoryEngin factory)
            {
                _abstractVoiture = factory.CreateVoiture();
                _abstractMoteur = factory.GetMoteurMarque();
            }

            public void Run()
            {
                _abstractVoiture.Compare(_abstractMoteur);
            }
        }



    }
}