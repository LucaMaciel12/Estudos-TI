#include <stdio.h>

int main()
{
    //Declarando as variáveis
    int ano, valor;
    
    //Solicitando que o usuário digte um número correspondente a um mês do ano
    printf("Digite um valor de 1 a 12: ");
    scanf("%d", &valor);
    
    switch(valor){
        case(4):
        case(6):
        case(9):
        case(11):
        
        printf("O mês tem 30 dias.");
        break;
        
        case(1):
        case(3):
        case(5):
        case(7):
        case(8):
        case(10):
        case(12):
        printf("O mês tem 31 dias.");
        break;
        
        case(2):
        
        printf("Digite o ano que vc quer: ");
        scanf("%d", &ano);
        
        if(ano % 400 == 0 || ano % 4 == 0 && ano % 100 != 0 ){
            printf("O mês tem 29 dias.");
        }
        else{
            printf("O mês tem 28 dias");
        }
        break;
        
        default:
        printf("O valor digitado é inválido.");
    }
    
    return 0;
}
