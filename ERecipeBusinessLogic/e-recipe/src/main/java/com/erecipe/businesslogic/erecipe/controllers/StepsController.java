package com.erecipe.businesslogic.erecipe.controllers;

import java.io.IOException;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RestController;

import com.erecipe.businesslogic.erecipe.DaoServices.StepsDaoService;
import com.erecipe.businesslogic.erecipe.Persistance.PersistanceLink;
@RestController
public class StepsController {
	@Autowired
	private StepsDaoService service;
	
	@GetMapping("/steps")
	public String GetSteps() throws IOException
	{
		return service.GetSteps();
	}
	@GetMapping("/steps/{id}")
	public String GetStep(@PathVariable int stepId) throws IOException
	{
		return service.GetStep(stepId);
	}
	@GetMapping("/steps/recipes/{id}")
	public String GetStepsOFRecipe(@PathVariable int recipeId) throws IOException
	{
		return service.GetStepsOFRecipe(recipeId);
	}
	@GetMapping("/steps/{id}/recipes")
	public String GetRecipeFromStep(@PathVariable int stepId) throws IOException
	{
		return service.GetRecipeFromStep(stepId);
	}
	
}
