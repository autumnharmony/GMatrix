
using System;

namespace GMatrix
{
	
	
	public class Matrix
	{
		public int n,m;
        public int[,] matrix;
        
        //TODO работает только для квадратных
        public Matrix(int[,] a)
        {
        	n = Convert.ToInt32(Math.Round(Math.Sqrt(a.Length)));
            m = n;
			matrix = a;
        }
        
        #region	Operaions
        
        
		public static Matrix operator + (Matrix a, Matrix b){
			Matrix c = new Matrix(a.n,a.m);
		
			if (a.n == b.n && a.m == b.m){
				for (int i=0; i<a.n; i++){
					for (int j=0;j<a.m;j++){
						c[i,j] = a[i,j]+b[i,j];
					}
						
				}
			}
		
			return c;
	
		}
			
		public static Matrix operator - (Matrix a, Matrix b){
			Matrix c = new Matrix(a.n,a.m);
			if (a.n == b.n && a.m == b.m){
				for (int i=0; i<a.n; i++){
					for (int j=0;j<a.m;j++){
						c[i,j] = a[i,j]-b[i,j];
					}
						
				}
			}
	
			return c;
		}
			
			
		
		public static Matrix operator * (Matrix a , Matrix b){
			
			
			if ((a.n == b.m) || (a.m == b.n)) {
			
				
				Matrix c = new Matrix(a.n,Math.Min(a.m,b.m));
				for (int i=0; i<a.n; i++) {
					for (int k=0; k<b.m; k++) {
						for (int j=0; j<a.m; j++){
							Console.WriteLine("c[{0},{1}] = {2} + a[{0},{3}]*b[{0},{1}]",i+1,k+1,c[i,k],j+1);
							//Console.WriteLine("c[{0},{1}] = {2} + {3}*{4}",				 i+1,k+1,c[i,k],a[i+1,j+1],b[i+1,k+1]);
							Console.WriteLine();
							c[i,k]+=a[i,j]*b[j,k];
						}
						
					}
				} 
				return c;
			} else {
                throw new Exception("Умножение матриц невозможно");
                //Console.Write("Умножение матриц невозможно"); return null; 
            }
			
		}
        #endregion
        
		#region I/O
		
		public void input(){
			for (int i=0; i<n; i++){
					for (int j=0;j<m;j++){
				 		matrix[i,j] = Convert.ToInt32(Console.ReadLine());
					}
					
			}
		}

		
		public void output(){
			for (int i=0; i<this.n; i++){
					for (int j=0;j<this.m;j++){
						Console.Write("{0,5}",this.matrix[i,j]);
					}
                    Console.WriteLine();
			}
		}
		
		#endregion        

		private double Det2x2(){
			if ((this.n == 2) && (this.m == 2)){
				return this[0,0]*this[1,1]-this[0,1]*this[1,0];
			} else {
                throw new Exception("Ошибка, матрица не 2x2");
            }
			
		}
		
		public Matrix Minor( int a, int b){
            //Console.WriteLine("Minor called");
			int i, j, p, q;
            Matrix MEN = new Matrix(n - 1, n - 1);
            for (j = 0, q = 0; q < MEN.m; j++, q++)
                for (i = 0, p =    0; p < MEN.n; i++, p++)
                {
                    if (i == a) i++;
                    if (j == b) j++;
                    MEN[p, q] = this[i, j];
                }
            return MEN;
			
		}
		
		
		public static double Det(Matrix B)
        {
            int n;
            int signo;
            double det = 0;

            if (B.n != B.m)
            {
                throw new Exception("Матрица должна быть квадратной");
            }
            else
                if (B.n == 1)
                    return B[0, 0];
                else
                    if (B.n == 2)
                        return B.Det2x2();
                    else
                        for (n = 0; n < B.m; n++)
                        { 
                            if ((n % 2) == 0)
                            {
                                signo = 1;
                            }
                            else
                            {
                                signo = -1;
                            }

                            Matrix mm = B.Minor(0, n);
                            
                            //det = det + signo * Convert.ToByte(B[0, n]) * Det(B.Minor(0, n));
                            det = det + signo * B[0, n] * Det(B.Minor(0, n));
                        }

            return det;
        }
		
		#region inverse
		/*
		public Matrix InverseMatrix(){
			bool[,] flags = new bool[this.n,this.m];
			int i,j;
		 	double tmp;
			Matrix nM = new Matrix(this.n,this.m);
			
					
			for (i = 0; i < this.n; i++){
                for (j = 0; j < this.m; j++)
                {
					nM[i,j] = Det(this.Minor(i,j));
				}
			}
			
			for (i = 0; i < this.n; i++){
                for (j = 0; j < this.m; j++) {
					if (flags[i,j]==false){
						nM[j,i] = nM[i,j];
					} else {	
						tmp = nM[i,j];
						nM[i,j] = nM[j,i];
						nM[j,i] = tmp;
						flags[j,i] = true;
					}
				}
			}
			
			
			
			for (i=0;i< nM.n; i++){
				for (j=0; j<nM.m;j++) {
					nM[i,j] = nM[i,j] / Det(this);
				}
			}
			
			return nM;
			
			
			
		}
		*/
		#endregion			
		
		public int this[int i, int j]
   		{
      		get { return matrix[i,j]; }
      		set { matrix[i,j] = value; }
   		}
		

					
		public Matrix(int n, int m)
		{
			this.n = Convert.ToByte(n);
			this.m = Convert.ToByte(m);
		    matrix = new int[n,m];
		}
		
		
		
		
			
	}
}