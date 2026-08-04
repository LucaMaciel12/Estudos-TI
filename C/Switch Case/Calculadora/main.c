#include <stdio.h>

int main()
{
    //Declarando as variáveis
    float num1, num2,resultado;
    char operacao;
    
    //Solicitando que o usuário digite um número
    printf("Digite um número: ");
    scanf("%f", &num1);

    //Solicitando que o usuário digite um número
    printf("\nDigite um número: ");
    scanf("%f", &num2);
    
    //Solicitando que o usuário digite a operação
    printf("\nDigite a operação (+), (-), (/), (*): ");
    scanf("%s", &operacao);
    
    switch(operacao){
        case ('+'):
        resultado = num1 + num2;
        printf("\nO valor da operação é: %1.f", resultado);
        break;

        case ('-'):
        resultado = num1 - num2;
        printf("\nO valor da operação é: %1.f", resultado);
        break;
        
        case ('*'):
        resultado = num1 * num2;
        printf("\nO valor da operação é: %1.f", resultado);
        break;
        
        case ('/'):
        if (num2 == 0){
            printf("\nOperaçao inválida");
        }
        else{
        resultado = num1 / num2;
        printf("\nO valor da operação é: %1.f", resultado);
        }
        break;
        
        
    default:
    printf("\nDigitação inválida.");
    }
    
    return 0;
}
