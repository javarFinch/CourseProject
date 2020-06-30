import { Component } from '@angular/core';
import {HttpClient} from '@angular/common/http'
import {FormsModule} from "@angular/forms"

@Component({
  selector: 'courses',
  templateUrl: './courses.component.html',
})
export class CoursesComponent {
  title = 'coursesui';
  courses = [];
  course:any = {};
  isEdit:boolean = false;
  showForm:boolean = false;
  public constructor(private HttpClient:HttpClient) {
      this.course.instructor = {};
      this.getCourses();
  }

  getCourses() {
      console.log("Something is happening... getting your courses");
      this.HttpClient.get('https://localhost:44397/courses').subscribe((data) => this.getCoursesSuccess(data), 
      (error) => this.getCoursesError(error));
  }

  getCoursesSuccess(data) {
      console.log("Yay We got the data data data data data");
      console.log(data);
      this.courses = JSON.parse(JSON.stringify(data));
  }

  getCoursesError(error) {
      console.log("Something went wrong");
      console.log(error);
  }

  delete(courseId) {
      this.HttpClient.delete("https://localhost:44397/courses/" + courseId).subscribe(() =>this.onSuccess(), () =>this.onError());
  }

  onSuccess() {
      console.log("Request processed Yay!!!");
      this.getCourses();
      this.course = {};
      this.course.instructor = {};
  }

  onError() {
      console.log("Bitch you thought!!");
      console.log("Something went horribly wrong :(");
  }

  save() {
      console.log(this.course);
      console.log("isEdit status: " + this.isEdit);
      if (this.isEdit) {
        this.HttpClient.put("https://localhost:44397/courses/", this.course).subscribe(() => this.onSuccess(), () => this.onError() )
        this.getCourses();
        this.isEdit = false;
        this.showForm = false;
      } else {
      this.HttpClient.post("https://localhost:44397/courses/", this.course).subscribe(() => this.onSuccess(), () => this.onError() )
      this.getCourses();
      this.showForm = false;
      }
  }

  edit(id) {
      this.isEdit = true;
      this.showForm = true;
      console.log(this.isEdit);
    this.HttpClient.get("https://localhost:44397/courses/" + id).subscribe((data:any) =>{    
    this.course = JSON.parse(JSON.stringify(data))
    }, 
    () =>this.onError()
  );
  }

  addCourse() {
      this.showForm = true;
  }
  cancel() {
    this.showForm = false;
}
}