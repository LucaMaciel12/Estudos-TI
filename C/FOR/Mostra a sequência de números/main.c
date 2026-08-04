#include <stdio.h>
int main(){
    
    int num,num2;
    
    printf("Digite o primeiro numero: ");
    scanf("%d", &num);
    
    printf("Digite o segundo numero: ");
    scanf("%d", &num2);
    
    for(num; num <= num2; num++){
        printf("%d ", num);
    }
return 0;
}
