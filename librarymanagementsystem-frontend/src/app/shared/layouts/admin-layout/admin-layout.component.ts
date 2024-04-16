import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HeaderComponent } from '../../components/header/header.component';
import { SidebarComponent } from '../../components/sidebar/sidebar.component';
import { AsideComponent } from '../../components/aside/aside.component';
import { RouterModule } from '@angular/router';
import { ToolbarComponent } from '../../toolbar/toolbar.component';



@Component({
  selector: 'app-admin-layout',
  standalone: true,
  imports: [CommonModule, FormsModule, HeaderComponent, SidebarComponent, AsideComponent,RouterModule, ToolbarComponent],
  templateUrl: './admin-layout.component.html',
  styleUrl: './admin-layout.component.scss'
})
export class AdminLayoutComponent  {



}