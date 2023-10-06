using System;

class Carro {
    private string modelo; // Atributo privado
    public string marca;   // Atributo público
    
    public Carro(string modelo, string marca) {
        this.modelo = modelo;
        this.marca = marca;
    }

    public Carro(){ //Esse segundo construtor serve para caso eu queira criar o new carro vazio e fornecer os valores de marca e modelo nas linhas abaixo. Ex linha 58 à 61.
      
    }
    
    public void ligarMotor() {
        Console.WriteLine("O motor está ligado.");
    }

    //Privado, só pode ser visto na class Carro.
    private void verificarCombustivel() { 
        Console.WriteLine("Verificando nível de combustível.");
    }

    //Método publico que chama o método privado, possibilitando ser utilizado na class Program utilizando realizarVerificarCombustivel().
    public void realizarVerificarCombustivel(){
      verificarCombustivel();
    }

    //Método protegido, pode ser utilizado na classe CarroEsportivo porque está herdando os métodos da class Carro (CarroEsportivo : Carro).
    protected void acelerar() {
        Console.WriteLine("Acelerando o carro.");
    }
}

class CarroEsportivo : Carro {
    public CarroEsportivo(string modelo, string marca) : base(modelo, marca) {
    }
    
    public void correr() {
        Console.WriteLine("Correndo em alta velocidade!");
        acelerar(); // Método protegido é acessível nas subclasses.
    }
}

class Program {
    static void Main(string[] args) {
        Carro Carro1 = new Carro("Sedan", "Toyota");
        Console.WriteLine("O carro é da marca: " + Carro1.marca);
        Console.WriteLine($"O carro é marca: {Carro1.marca}");
        //Não é possível fazer a busca do modelo porque o atributo é privado na class Carro.
        Carro1.ligarMotor(); // Método público acessível fora da classe

        Carro1.realizarVerificarCombustivel(); 
        //Aqui chamo o método realizarVerificarCombustivel que está publico na class Carro.

      

        Carro Carro2 = new Carro();
        Carro2.marca = "Subaru";
        Console.WriteLine($"O carro é um {Carro2.marca}");
        Carro2.ligarMotor();
        

        
        
        CarroEsportivo carroEsportivo = new CarroEsportivo("Esportivo", "Ferrari");
        Console.WriteLine($"O carro esportivo é uma {carroEsportivo.marca}");
        carroEsportivo.correr(); // Método público da classe base
    }
}
