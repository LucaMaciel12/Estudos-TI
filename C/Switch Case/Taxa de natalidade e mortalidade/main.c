#include <stdio.h>

int main()
{
    int opcao, natalidade=0, mortalidade=0, habitantes, criancas, mortes;
    
    printf("Escolha uma taxa para calcula");
    printf("\n1-Natalidade \t2-Mortalidade \t");
    scanf("%d", &opcao);
    
    
    printf("\nDigite o numero de Habitantes: ");
    scanf("%d", &habitantes);
    
    
    switch(opcao){
        case 1:
        printf("\nDigite o numero de crianças: ");
        scanf("%d", &criancas);
        
        natalidade = (criancas*1000)/habitantes;
        
        printf("\nA taxa de natalidade é de: %d", natalidade);
        break;
        
        case 2:
        printf("Digite o numero de óbitos: ");
        scanf("%d", &mortes);
        
        mortalidade =(mortes*1000)/habitantes;
        
        printf("\nA taxa de mortalidade é de: %d", mortalidade);
        break;
        
        default:
        printf("Digitação Invalida");
    }

    return 0;
}
