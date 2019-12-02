package com.erecipe.businesslogic.erecipe.DaoServices;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;

import org.springframework.stereotype.Component;

import com.erecipe.businesslogic.erecipe.Persistance.PersistanceLink;

@Component
public class StepsDaoService {

	public String GetSteps() throws IOException
	{
		return PersistanceLink.GetSteps();
	}

	public String GetStep(int stepId) throws IOException
	{
		return PersistanceLink.GetStep(stepId);
	}
	
	public String GetStepsOFRecipe(int recipeId) throws IOException
	{
		return PersistanceLink.GetStepsOFRecipe(recipeId);
	}
	
	public String GetRecipeFromStep(int stepId) throws IOException
	{
		return PersistanceLink.GetRecipeFromStep(stepId);
	}
	
	
}
