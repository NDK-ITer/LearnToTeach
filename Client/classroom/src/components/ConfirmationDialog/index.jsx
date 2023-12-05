import React from 'react';
import { Button, Dialog, DialogTitle, DialogContent, DialogActions } from '@material-ui/core';

const ConfirmationDialog = ({ open, onClose, onConfirm, message }) => {
  const handleConfirm = () => {
    onConfirm();
    onClose();
  };

  return (
    <Dialog open={open} onClose={onClose}>
      <DialogTitle>Thông báo xác nhận</DialogTitle>
      <DialogContent dividers>
        <p>{message}</p>
      </DialogContent>
      <DialogActions>
        <Button onClick={handleConfirm} color="primary">
          Có
        </Button>
        <Button onClick={onClose} color="secondary">
          Không
        </Button>
      </DialogActions>
    </Dialog>
  );
};

export default ConfirmationDialog;
