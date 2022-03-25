package com.example.testRest;

import org.junit.jupiter.api.Test;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.context.annotation.ComponentScan;
import org.springframework.data.jpa.repository.config.EnableJpaRepositories;

@SpringBootTest
@ComponentScan({"com.example.testRest.*"})
@EnableJpaRepositories("com.example.testRest.*")
class TestRestApplicationTests {

	@Test
	void contextLoads() {
	}

}
