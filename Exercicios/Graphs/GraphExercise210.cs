namespace Exercicios.Graphs;

public class GraphExercise210
{
    public int[] FindOrder(int numCourses, int[][] prerequisites)
    {
        Dictionary<int, List<int>> coursesPreRequisites = new Dictionary<int, List<int>>(); //Esse sera nosso hashMap que ira guardar como chave o curso, e como valor os pre-requisitos desse curso.

        //No for abaixo iremos preencher nosso hashMap com os cursos e seus prerequisitos.
        foreach (var pair in prerequisites) 
        {
            if (!coursesPreRequisites.ContainsKey(pair[0])) 
            {
                coursesPreRequisites[pair[0]] = new List<int>();
            }
            coursesPreRequisites[pair[0]].Add(pair[1]);
        }

        List<int> output = new List<int>(); //Essa sera a nossa variavel que ira guardar a ordem correta de se fazer os cursos, portanto, sera nossa resposta.
        HashSet<int> visited = new HashSet<int>(); //Essa variavel ira guardar quais nodes ja foram visitados em um determinado fluxo.
        HashSet<int> cycle = new HashSet<int>();

        for (int course = 0; course < numCourses; course++) 
        {
            if (!DFS(course, coursesPreRequisites, visited, cycle, output)) //Caso nossa funcao DFS retorne false, entao o ! transformara em true, e entraremos no if, que ira retornar um array vazio, ou seja, so ira chegar nesse cenario se houver um ciclo nos cursos e nao for possivel realizar todos eles.
            {
                return new int[0];
            }
        }

        return output.ToArray();
    }

    private bool DFS(int course, Dictionary<int, List<int>> coursesPreRequisites, HashSet<int> visited, HashSet<int> cycle, List<int> output) 
    {
        if (cycle.Contains(course)) //Se o curso que estamos analisando ja estiver presente no nosso hashSet de ciclos, entao definitivamente ha um ciclo, portanto nao ha como finalizar todos os cursos, e retornamos false.
            return false;

        if (visited.Contains(course)) //Se o curso atual ja foi visitado, entao retornamos true, pois ele ja foi visitado, seu processo ja foi concluido.
            return true;

        cycle.Add(course); //Antes de analisar os prerequisitos do curso atual, nos vamos adiciona-lo ao nosso hashSet que ira manter controle se ha um ciclo ou nao.
       
        //Agora sim iremos analisar os prerequisitos do curso atual.
        if (coursesPreRequisites.ContainsKey(course)) 
        {
            foreach (int pre in coursesPreRequisites[course]) 
            {
                if (!DFS(pre, coursesPreRequisites, visited, cycle, output)) //Se em algum momento houver um ciclo, ele ira retornar false, entrando nesse if e finalizando o DFS, ate chegar na primeira chamada, onde tambem sera retornado false e portanto, a resposta do exercicio sera um array vazio, pois nao ha como fazer todos os cursos.
                {
                    return false;
                }
            }
        }

        cycle.Remove(course); //Depois que analisamos todos os pre-requisitos do curso, ai podemos retirar o curso atual da nossa variavel que checa ciclos, pois na proxima iteracao do DFS, a nossa variavel de ciclos deve estar vazia.
        visited.Add(course); //No fim do processo nos adicionamos o node atual a variavel visited, pois se em nenhum momento ele retornou false e chegou ate aqui, entao eh possivel fazer os cursos ate o momento, e portanto esse curso atual eh "fazivel" e para as proximas iteracoes, ele nao precisa ser analisado se eh possivel faze-lo ou nao, pois ja sabemos com certeza de que eh sim possivel.
        output.Add(course); //E por fim, adicionamos o curso/node atual a nossa variavel final, isso aqui ficara em ordem do "ultimo curso", ou no caso, o que nao tem nenhum pre-requisito, ate o curso que teve como requisito varios cursos anteriores, e o nosso DFS ja ira cuidar disso, no fim essa variavel tera a ordem correta que os cursos devem ser feitos.
        return true; //Retornamos true para nao cairmos nas condicoes (!) que irao retornar uma lista vazia, pois isso so pode acontecer se houver um ciclo, que nao eh o caso.
    }
}
