using System;
/* problem text
 * a positive response
 * an average response
 * a refusal response
 * weight for positive to average
 * 
 */

public class Problem
{
	public string problemText;
	public string positiveResponse;
	public string averageResponse;
	public string refusalResponse;
	int positiveWeight = 5; //lets say we have 0 to 10 (10 being the positive response)

	public Problem(string problem, string pos, string avg, string refusal)
	{
		problemText = problem;
		positiveResponse = pos;
		averageResponse = avg;
		refusalResponse = refusal;
	}

	public void ChangeAnswerWeight(int value)
	{
		positiveWeight += value;
	}

	public string GetResponse(bool accepted)
	{
		if (!accepted)
			return refusalResponse;
		Random randObj = new Random( 234 );
		int randDecider = randObj.Next (0, 10);
		if (positiveWeight >= randDecider) {
			return positiveResponse;
		}
		return averageResponse;
	}
}