public class ShellSort{
	

public int DoSort(int[] input)
{
	if (input == null || input.Length <= 1)
	{
		return input;
	}
	
	
	int h = 1;
	
	while (h < input.Length/3)
		{
			h=3*h+1;
		}
	
	while (h>=1)
	{
		for (int i = h; i < input.Length; i++)
		{
			for (int j = i; j>=0; j= j - h)
			{
				if (input[j] < input[j-h])
					{
						Swap(input, j, j-h)
					}
					else
					{
						break;
					}
			}		
		}
		
		h = h/3;
	}
	return input;
}
}