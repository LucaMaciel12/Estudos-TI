#include <stdio.h>

int main()
{
    float num1, num2, operador=0;
    int  condicao_parada;
    char opcao;
    
    do{
    printf("Digite um número: ");
    scanf("%f", &num1);
    
    printf("\nDigite um número: ");
    scanf("%f", &num2);
    
    printf("\nEscolha a operação!");
    printf("\nDigite (+) adição, (-) subtração, (*) multiplicação, (/) divisão: ");
    scanf(" %c", &opcao);
    
  
   
    switch (opcao){
        case ('+'):
        
        operador = num1+num2;
        
        printf("\nO valor da adição entre os dois números é: %0.2f", operador);
        break;
        
        case ('-'):
        
        operador = num1-num2;
        
        printf("\nO valor da subtração entre os dois números é: %0.2f", operador);
        break;
        
        case ('*'):
        
        operador = num1*num2;
        
        printf("\nO valor da multiplicação entre os dois números é: %0.2f", operador);
        break;
        
        case ('/'):
        
        if(num2 == 0){
            printf("\nDigitação invalida");
        }
        
        else{
        operador = num1/num2;
        printf("\nO valor da divisão entre os dois números é: %0.2f", operador);
        }
          break;  
       
        
        default:
        printf("\nDigitação inválida");
    }
    
    
        printf("\nDigite 0 para encerrar o programa e 1 para fazer uma nova operação: ");
    scanf("%d", &condicao_parada);
    }
    
      while(condicao_parada == 1);
       
    
    
    
    return 0;
    
}
