using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

// Cria a lista de suítes
List<Suite> suites = new List<Suite>();

// Cria a lista de hóspedes
List<Pessoa> hospedes = new List<Pessoa>();

// Cria a lista de reservas
List<Reserva> reservas = new List<Reserva>();

// Cria o menu interativo
int opcao = 0;


Pessoa p1 = new Pessoa(nome: "Hóspede 1");
Pessoa p2 = new Pessoa(nome: "Hóspede 2");

hospedes.Add(p1);
hospedes.Add(p2);

Suite suuite = new Suite(tipoSuite: "Premium", capacidade: 2, valorDiaria: 30);

Reserva reservaa = new Reserva(diasReservados: 10);
reservaa.CadastrarSuite(suuite);
reservaa.CadastrarHospedes(hospedes);

reservas.Add(reservaa);

while (opcao != 5)
{
  Console.WriteLine("1 - Cadastrar suíte");
  Console.WriteLine("2 - Cadastrar hóspede");
  Console.WriteLine("3 - Cadastrar reserva");
  Console.WriteLine("4 - checkout");
  Console.WriteLine("5 - Sair");
  Console.Write("Escolha uma opção: ");
  opcao = int.Parse(Console.ReadLine());

  switch (opcao)
  {
    case 1:
      Console.Write("Tipo da suíte: ");
      string tipoSuite = Console.ReadLine();
      Console.Write("Capacidade: ");
      int capacidade = int.Parse(Console.ReadLine());
      Console.Write("Valor diária: ");
      decimal valorDiaria = decimal.Parse(Console.ReadLine());

      Suite suite = new Suite(tipoSuite, capacidade, valorDiaria);
      suites.Add(suite);
      Console.WriteLine("\n=========================================================\n");
      break;
    case 2:
      Console.Write("Nome do hóspede: ");
      string nome = Console.ReadLine();

      Pessoa hospede = new Pessoa(nome);
      hospedes.Add(hospede);
      break;
    case 3:
      if (suites.Count == 0)
      {
        Console.WriteLine("Cadastre uma suíte antes de criar uma reserva");
        Console.WriteLine("\n=========================================================\n");
        break;
      }

      if (hospedes.Count == 0)
      {
        Console.WriteLine("Cadastre um hóspede antes de criar uma reserva");
        Console.WriteLine("\n=========================================================\n");
        break;
      }

      Console.Write("Dias reservados: ");
      int diasReservados = int.Parse(Console.ReadLine());

      Reserva reserva = new Reserva(diasReservados);
      Console.WriteLine("Suítes disponíveis:");
      for (int i = 0; i < suites.Count; i++)
      {
        Console.WriteLine($"{i + 1} - {suites[i].TipoSuite}");
      }
      Console.Write("Escolha uma suíte: ");
      int indiceSuite = int.Parse(Console.ReadLine()) - 1;
      reserva.CadastrarSuite(suites[indiceSuite]);

      Console.WriteLine("Hóspedes disponíveis:");
      for (int i = 0; i < hospedes.Count; i++)
      {
        Console.WriteLine($"{i + 1} - {hospedes[i].Nome}");
      }
      Console.Write("Escolha um hóspede: ");
      int indiceHospede = int.Parse(Console.ReadLine()) - 1;
      reserva.CadastrarHospedes
      (
          new List<Pessoa>
          {
                    hospedes[indiceHospede]
          }
      );
      reservas.Add(reserva);

      Console.WriteLine("\n=========================================================\n");
      break;

    case 4:
      Console.WriteLine("Reservas disponíveis:");
      for (int i = 0; i < reservas.Count; i++)
      {
        Console.WriteLine($"{i + 1} - {reservas[i].ObterQuantidadeHospedes()} hóspedes");
      }
      Console.Write("Escolha uma reserva: ");
      int indiceReserva = int.Parse(Console.ReadLine()) - 1;
      Console.WriteLine($"Valor total da reserva: {reservas[indiceReserva].CalcularValorDiaria()}");
      Console.WriteLine("Reserva encerrada\n=========================================================\n");
      break;
    case 5:
      Console.WriteLine("Saindo...");
      break;
    default:
      Console.WriteLine("Opção inválida");
      break;
  }
}




// // Cria os modelos de hóspedes e cadastra na lista de hóspedes
// List<Pessoa> hospedes = new List<Pessoa>();

// Pessoa p1 = new Pessoa(nome: "Hóspede 1");
// Pessoa p2 = new Pessoa(nome: "Hóspede 2");

// hospedes.Add(p1);
// hospedes.Add(p2);

// // Cria a suíte
// Suite suite = new Suite(tipoSuite: "Premium", capacidade: 2, valorDiaria: 30);

// // Cria uma nova reserva, passando a suíte e os hóspedes
// Reserva reserva = new Reserva(diasReservados: 10);
// reserva.CadastrarSuite(suite);
// reserva.CadastrarHospedes(hospedes);

// // Exibe a quantidade de hóspedes e o valor da diária
// Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
// Console.WriteLine($"Valor diária: {reserva.CalcularValorDiaria()}");