package com.erecipe.businesslogic.erecipe.DaoServices;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;
import java.util.ArrayList;
import java.util.List;

import org.springframework.stereotype.Component;

import com.erecipe.businesslogic.erecipe.Persistance.PersistanceLink;
import com.erecipe.businesslogic.erecipe.model.*;
import com.google.gson.Gson;
import com.google.gson.JsonArray;
import com.google.gson.JsonSyntaxException;

@Component
public class AuthorDaoSerivce {

	public String GetAuthors() throws IOException
	{
		return PersistanceLink.GetAuthors();
	}
	
	public String GetAuthor(int authorId) throws IOException
	{
		return PersistanceLink.GetAuthor(authorId);
	}
	
	public String GetRecipeByAuthor(int authorId) throws IOException
	{
		return PersistanceLink.GetRecipeByAuthor(authorId);
	}

	public String GetAuthorsOfARecipe(int recipeId) throws IOException
	{
		return PersistanceLink.GetAuthorsOfARecipe(recipeId);
	}

}
