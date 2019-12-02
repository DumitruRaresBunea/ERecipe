package com.erecipe.businesslogic.erecipe;

import java.io.IOException;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;

import com.erecipe.businesslogic.erecipe.Persistance.PersistanceLink;

@SpringBootApplication
public class ERecipeApplication {

	public static void main(String[] args) throws IOException {
		SpringApplication.run(ERecipeApplication.class, args);
		
	}

}
