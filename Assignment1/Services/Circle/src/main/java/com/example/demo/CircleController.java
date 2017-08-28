package com.example.demo;

import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class CircleController {

    @RequestMapping("/getCircleArea")
    public Circle getCircleArea(@RequestParam(value="radius") double radius) {
        return new Circle(radius, (3.14*radius*radius));
    }
}
