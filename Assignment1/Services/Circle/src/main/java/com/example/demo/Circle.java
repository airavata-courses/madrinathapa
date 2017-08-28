package com.example.demo;

public class Circle {

    private final double Radius;
    private final double Area;

    public Circle(double radius, double area) {
        this.Radius = radius;
        this.Area = area;
    }

    public double getRadius() {
        return Radius;
    }

    public double getArea() {
        return Area;
    }
}
