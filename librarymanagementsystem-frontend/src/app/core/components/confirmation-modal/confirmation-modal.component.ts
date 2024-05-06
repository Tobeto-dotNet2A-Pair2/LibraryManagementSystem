import { CommonModule } from "@angular/common";
import { Component, Input } from "@angular/core";
import { NgbActiveModal, NgbModule } from "@ng-bootstrap/ng-bootstrap";


@Component({
  selector: 'app-confirmation-modal',
  standalone: true,
  imports: [CommonModule, NgbModule ],
  templateUrl: './confirmation-modal.component.html',
  styleUrls: ['./confirmation-modal.component.scss']
})
export class ConfirmationModalComponent {
  @Input() title!: string;
  @Input() message!: string;
  @Input() cancelButtonText!: string;
  @Input() confirmButtonText!: string;
  
  constructor(private activeModal: NgbActiveModal) {}

  confirm() {
    // Onay işlemi burada gerçekleştirilir
    console.log('Onaylandı.');
    // Modalı kapat
    this.activeModal.close('confirm');
  }

  dismiss() {
    // İptal işlemi burada gerçekleştirilir
    console.log('İptal edildi.');
    // Modalı kapat
    this.activeModal.dismiss('cancel');
  }
}