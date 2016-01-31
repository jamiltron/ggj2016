﻿using UnityEngine;
using System;

/* problem text
 * a positive response
 * an average response
 * a refusal response
 * weight for positive to average
 * 
 */

public class Problem : ScriptableObject {
  public ProblemType problemType;

  public string problemText;
  public string helpAcceptedText;
  public string helpDeclinedText;
  public string positiveResponse;
  public string averageResponse;
  public string negativeResponse;
  public string refusalResponse;
  public bool accepted = false;
  public int rating;

  int positiveWeight = 5;
  //lets say we have 0 to 10 (10 being the positive response)

  public Problem(string problem, string pos, string avg, string refusal, 
                 string helpAcceptedText, string helpDeclinedText, ProblemType problemType = ProblemType.Misc) {
    problemText = problem;
    positiveResponse = pos;
    averageResponse = avg;
    refusalResponse = refusal;
    this.helpAcceptedText = helpAcceptedText;
    this.helpDeclinedText = helpDeclinedText;
    this.problemType = problemType;
  }

  public void ChangeAnswerWeight(int value) {
    positiveWeight += value;
  }

  public string GetResponse() {
    return "";
    /*if (!accepted) {
      return refusalResponse;
    }

    int rating = UnityEngine.Random.Range(1, 5);
    if (positiveWeight >= randDecider) {
      return positiveResponse;
    }
    return averageResponse;*/
  }
}