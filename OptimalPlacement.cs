// TC => O(HW) + HW(P)n --> permutations
// SC => O(HW)

/*
Q 1. Given a grid with w as width, h as height. Each cell of the grid represents a potential building lot and we will be adding "n" buildings inside this grid. The goal is for the furthest of all lots to be as near as possible to a building. Given an input n, which is the number of buildings to be placed in the lot, determine the building placement to minimize the distance the most distant empty lot is from the building. Movement is restricted to horizontal and vertical i.e. diagonal movement is not required.

For example, w=4, h=4 and n=3. An optimal grid placement sets any lot within two unit distance of the building. The answer for this case is 2.
*/
class HelloWorld {
    static int minDistance;
    static int[][] result;
    public static int FindMinDistance(int H,int W, int n){
            int[][] grid = new int[H][];
            for(int i =0; i < H;i++){
                grid[i] = new int[W];
                for(int j = 0; j< W; j++){
                    grid[i][j] = -1;
                }
            }
            Backtrack(grid, 0,0,n, H, W);
            return minDistance;
        }
        
        public static void BFS(int[][] grid, int H, int W){
            Queue<int[]> queue = new Queue<int[]>();
            bool[][] visited = new bool[H][];
            
            for(int i = 0; i < H; i++){
                visited[i] = new bool[W];
                for(int j = 0; j < W; j++){
                    if(grid[i][j] == 0){
                        queue.Enqueue([i, j]);
                        visited[i][j] = true;
                    }
                }
            }
            
            int distance = 0;
            int[][] dirs = [[-1,0], [1,0], [0,-1], [0,1]];
            while(queue.Count > 0){
                int size = queue.Count;
                for(int i = 0; i < size; i++){
                    int[] current = queue.Dequeue();
                    foreach(var dir in dirs){
                        int nr = current[0] + dir[0];
                        int nc = current[1] + dir[1];
                        if(nr >= 0 && nr < H && nc >= 0 && nc < W && !visited[nr][nc]){
                            queue.Enqueue([nr, nc]);
                            visited[nr][nc] = true;
                        }
                    }
                }
                distance++;
            }
            if(distance - 1 < minDistance){
                minDistance = distance - 1;
                result = new int[H][];
                for(int i = 0; i< H; i++){
                    result[i] = new int[W];
                    for(int j = 0; j < W; j++){
                        result[i][j] = grid[i][j];
                    }
                }
            }
            // minDistance = Math.Min(minDistance, distance - 1);
        }
        public static void Backtrack(int[][] grid, int row, int column, int n, int H, int W){
            //base
            if(n == 0){
                BFS(grid, H, W);
                return;
            }
            if(column == W){
                row++;
                column = 0;
            }
            //logic
            for(int i = row; i< H;i++){
                for(int j = column; j < W; j++){
                    //action
                    grid[i][j] = 0;
                    
                    //recurse
                    Backtrack(grid, i, j+1, n-1, H, W);
                    
                    //backtrack
                    grid[i][j] = -1;
                    
                }
                column = 0;
            }
        }
        
    static void Main() {
        // BuildingPlacement bp = new BuildingPlacement();
        minDistance = Int32.MaxValue;
        Console.WriteLine(FindMinDistance(4,4,2));
        for(int i = 0; i< result.Length; i++){
            for(int j = 0; j < result[0].Length; j++){
                Console.Write(result[i][j] + " ");
            }
            Console.WriteLine();
        }
    }
}